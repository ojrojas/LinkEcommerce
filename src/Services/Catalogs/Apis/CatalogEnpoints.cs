namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty);

        api.MapGet("/getallitems", GetAllItems);
        api.MapGet("/getitembyid/{id:guid}", GetItemById);
        api.MapGet("/getitemsbybrandid/{brandid:guid}", GetItemsByBrandId);
        api.MapGet("/getitemsbybrandidandtypeid/brand/{brandid:guid}/type/{typeid:guid}", GetItemsByBrandIdAndTypeId);
        api.MapGet("/getitemsbynames", GetItemsByNames);

        api.MapPost("/create", CreateCatalogItem);
        api.MapPatch("/update", UpdateCatalogItem);
        api.MapDelete("/delete/{id:guid}", DeleteCatalogItem);
        return api;

    }

    public static async ValueTask<Results<Ok<DeleteCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> DeleteCatalogItem(
        [AsParameters] DeleteCatalogItemRequest request,
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.DeleteCatalogItemAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<UpdateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> UpdateCatalogItem(
        [AsParameters] UpdateCatalogItemRequest request, 
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.UpdateCatalogItemAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<CreateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> CreateCatalogItem(
        [AsParameters] CreateCatalogItemRequest request, 
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.CreateCatalogItemAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<GetCatalogItemsByNamesResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByNames(
        [AsParameters] PaginationByNamesRequest request,
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemByNamesAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<GetItemsByBrandAndTypeIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandIdAndTypeId(
        [AsParameters] PaginationByBrandIdAndTypeIdRequest request,
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAndTypeIdAsync(request, cancellationToken));
    }

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
        [AsParameters] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.PaginatedItemsAsync(request, cancellationToken));
    }
}