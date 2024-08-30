using Microsoft.AspNetCore.Http.HttpResults;

namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapGet("/getallitems", GetAllItems);

        return api;
    }

    public static async ValueTask<Results<Ok<PaginationResponse>, BadRequest<string>, ProblemHttpResult>> GetAllItems(
        [AsParameters] PaginationRequest request,
        [AsParameters] ICatalogService catalogService,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await catalogService.PaginatedItemsAsync(request, cancellationToken));
    }
}