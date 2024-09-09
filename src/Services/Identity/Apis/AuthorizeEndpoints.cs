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

        Console.WriteLine($"Counts identities {context.User.Identities.Count()}");
        foreach (var newIdentity in context.User.Identities)
        {
            foreach (var newClaim in newIdentity.Claims)
                Console.WriteLine($"{newClaim.ValueType} :::: {newClaim.Value}");
        }


        var application = await applicationManager.FindByClientIdAsync(request.ClientId) ??
        throw new InvalidOperationException("The application details cannot be found in the database.");

        // Create the claims-based identity that will be used by OpenIddict to generate tokens.

        var identity = new ClaimsIdentity(result.Principal.Claims,
            authenticationType: TokenValidationParameters.DefaultAuthenticationType,
            nameType: Claims.Name,
            roleType: Claims.Role);
        
        foreach(var response in result.Principal.Claims)
            Console.WriteLine($"{response.Subject.Name} ::: {response.Value}");

        // Add the claims that will be persisted in the tokens (use the client_id as the subject identifier).
        identity.SetClaim(Claims.Subject, result.Principal.FindFirst(x=> x.Type.Equals(ClaimTypes.NameIdentifier)).Value);
        identity.SetClaim(Claims.Name, result.Principal.FindFirst(x => x.Type == ClaimTypes.Name).Value);

        identity.SetScopes(request.GetScopes());
        var resources = await scopeManager.ListResourcesAsync(identity.GetScopes()).ToListExtensionsAsync();
        foreach (var resource in resources)
            Console.WriteLine($"Resource found {resource}");
        identity.SetResources(resources);
        identity.SetDestinations(GetDestination.GetDestinations);

        return Results.SignIn(new ClaimsPrincipal(identity), new(), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
    }
}