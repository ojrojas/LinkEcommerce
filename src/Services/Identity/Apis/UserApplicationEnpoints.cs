using Microsoft.AspNetCore.Authorization;
using OpenIddict.Validation.AspNetCore;

namespace LinkEcommerce.Services.Identity.Apis;

public static class UserApplicationEndpoints
{
    public static RouteGroupBuilder MapEndpointUserApplicationV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup("api/userapplication").HasApiVersion(1.0);

        api.MapPost("/createuserapplication", CreateUserApplication);
        api.MapPatch("/updateuserapplication", UpdateUserApplication);
        api.MapDelete("/deleteuserapplication", DeleteUserApplication);
        api.MapGet("/getuserapplicationbyid/{id:guid}", GetUserApplicationId);

#if DEBUG
        api.MapGet("/getallusers",
        [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
        async (HttpContext context, [FromServices] IUserApplicationServices services) =>
        TypedResults.Ok(await services.GetAllUsersAsync(new(), CancellationToken.None)));
#endif

        return api;
    }

    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    public static async ValueTask<Results<Ok<GetUserByIdResponse>, BadRequest<string>, ProblemHttpResult>> GetUserApplicationId(
        HttpContext context,
        [FromServices] IUserApplicationServices services,
        [FromRoute] Guid id, CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await services.GetUserByIdAsync(new(id)));
    }

    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    public static async ValueTask<Results<Ok<DeleteUserResponse>, BadRequest<string>, ProblemHttpResult>> DeleteUserApplication(
            HttpContext context,
            [FromServices] IUserApplicationServices services,
            [FromBody] DeleteUserRequest request,
            CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await services.DeleteUserAsync(request, cancellationToken));
    }

    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    public static async ValueTask<Results<Ok<UpdateUserResponse>, BadRequest<string>, ProblemHttpResult>> UpdateUserApplication(
            HttpContext context,
            [FromServices] IUserApplicationServices services,
            [FromBody] UpdateUserRequest request,
            CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await services.UpdateUserAsync(request, cancellationToken));
    }

    [Authorize(AuthenticationSchemes = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme)]
    public static async ValueTask<Results<Ok<CreateUserResponse>, BadRequest<string>, ProblemHttpResult>> CreateUserApplication(
            HttpContext context,
            [FromServices] IUserApplicationServices services,
            [FromBody] CreateUserRequest request,
            CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await services.CreateUserAsync(request, cancellationToken));
    }
}