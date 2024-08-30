


namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapGet("/getallitems", GetAllItems);
        api.MapGet("/getitembyid/{id:guid}", GetItemById);
        api.MapGet("/getitemsbybrandid/{brandid:guid}", GetItemsByBrandId);
       // api.MapGet("/getitemsbybrandidandtypeid/brand/{brandid:guid}/type/{typeid:guid}", GetItemsByBrandIdAndTypeId);
        // api.MapGet("/getitemsbynames", GetItemsByNames);

        // api.MapPost("/create", CreateCatalogItem);
        // api.MapPatch("/update", UpdateCatalogItem);
        // api.MapDelete("/delete/{id:guid}", DeleteCatalogItem);
        return api;

    }

    // private static async ValueTask<Results<Ok<GetCatalogItemsByBrandIdResponse GetItemsByBrandIdAndTypeId(HttpContext context)
    // {
    //     throw new NotImplementedException();
    // }

    public static async ValueTask<Results<Ok<GetCatalogItemsByBrandIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandId(
        [AsParameters] PaginationByBrandIdRequest request, 
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<GetCatalogItemByIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemById(
        [AsParameters] GetCatalogItemByIdRequest request,
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemByIdAsync(request, cancellationToken));
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