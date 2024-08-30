namespace LinkEcommerce.Services.Identity.Apis;
public static class AuthorizeEndpoints
{
    public static RouteGroupBuilder MapAuthorizeEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapMethods("/connect/authorize", [HttpMethods.Get, HttpMethods.Post], AuthorizeApp);
        api.MapPost("/connect/token", GetToken);
        api.MapMethods("/connect/logout", [HttpMethods.Get, HttpMethods.Post], Logout);

        return api;
    }

    private static async Task<IResult> Logout(HttpContext context, IConfiguration configuration)
    {
        await context.SignOutAsync(IdentityConstants.ApplicationScheme);
        return Results.Redirect($"{configuration["IdentityApiClient"]}/index");
    }

    public static async ValueTask<IResult> GetToken(HttpContext context, IUserApplicationServices services)
    {
        return await services.LoginAsync(context);
    }

    public static async ValueTask<IResult> AuthorizeApp(
        HttpContext context,
        IOpenIddictApplicationManager applicationManager,
        IOpenIddictScopeManager scopeManager)
    {
        var request = context.GetOpenIddictServerRequest() ?? throw new InvalidOperationException("Error request operation not found a valid request auth openid");
        var result = await context.AuthenticateAsync(IdentityConstants.ApplicationScheme);
#if DEBUG
        Console.WriteLine($"Authentication AuthorizeEndpoint : {result.Succeeded}");
#endif
        if (!result.Succeeded)
        {
            var prompt = string.Join(" ", request.GetPrompts().Remove(Prompts.Login));

            var parameters = context.Request.HasFormContentType ?
              context.Request.Form.Where(parameter => parameter.Key != Parameters.Prompt).ToList() :
              context.Request.Query.Where(parameter => parameter.Key != Parameters.Prompt).ToList();

            parameters.Add(KeyValuePair.Create(Parameters.Prompt, new StringValues(prompt)));

            var url = context.Request.PathBase + context.Request.Path + QueryString.Create(parameters);

            return Results.Challenge(properties: new AuthenticationProperties
            {
                RedirectUri = url,
            }, [IdentityConstants.ApplicationScheme]);
        }

        ArgumentNullException.ThrowIfNull(request.ClientId);

        var application = await applicationManager.FindByClientIdAsync(request.ClientId) ??
        throw new InvalidOperationException("The application details cannot be found in the database.");

        // Create the claims-based identity that will be used by OpenIddict to generate tokens.

        var identity = new ClaimsIdentity(
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);

        // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
        identity.SetClaim(Claims.Subject, await applicationManager.GetClientIdAsync(application));
        identity.SetClaim(Claims.Name, await applicationManager.GetDisplayNameAsync(application));

        identity.SetScopes(request.GetScopes());
        identity.SetResources(await scopeManager.ListResourcesAsync(identity.GetScopes()).ToListExtensionsAsync());
        identity.SetDestinations(GetDestination.GetDestinations);

        return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}