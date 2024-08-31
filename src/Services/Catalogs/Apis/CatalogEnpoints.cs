namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty).HasApiVersion(1.0);

        api.MapGet("/getallitems", GetAllItems);
        api.MapGet("/getitembyid/{id:guid}", GetItemById);
        api.MapGet("/getitemsbybrandid/{brandid:guid}", GetItemsByBrandId);
        api.MapGet("/getitemsbybrandidandtypeid/brand/{brandid:guid}/type/{typeid:guid}", GetItemsByBrandIdAndTypeId);
        api.MapGet("/getitemsbynames/pagesize/{pagesize:int}/pageindex/{pageindex:int}/names/{names}", GetItemsByNames);

        api.MapPost("/create", CreateCatalogItem);
        api.MapPatch("/update", UpdateCatalogItem);
        api.MapDelete("/delete/{id:guid}", DeleteCatalogItem);

        // api.MapGet("/", HelloWorld);

        return api;

    }

    // private static async ValueTask<string> HelloWorld(
    //     [FromServices] ICatalogService2 service,
    //     CancellationToken cancellationToken
    // )
    // {
    //     return await service.HelloAsync(cancellationToken);
    // }

    private static async ValueTask<Results<Ok<DeleteCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> DeleteCatalogItem(
        [FromRoute] Guid id,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.DeleteCatalogItemAsync(new(id), cancellationToken));
    }

    private static async ValueTask<Results<Ok<UpdateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> UpdateCatalogItem(
        [FromBody] UpdateCatalogItemRequest request, 
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.UpdateCatalogItemAsync(request, cancellationToken));
    }

    private static async ValueTask<Results<Ok<CreateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> CreateCatalogItem(
        [FromBody] CreateCatalogItemRequest request, 
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.CreateCatalogItemAsync(request, cancellationToken));
    }

    private static async ValueTask<Results<Ok<GetCatalogItemsByNamesResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByNames(
        [FromRoute] int pagesize, [FromRoute]int pageindex, [FromRoute]string names,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemByNamesAsync(new(names, pagesize, pageindex), cancellationToken));
    }

    private static async ValueTask<Results<Ok<GetItemsByBrandAndTypeIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandIdAndTypeId(
        [AsParameters] PaginationRequest request1,
        [FromRoute] Guid brandid, [FromRoute] Guid typeid,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAndTypeIdAsync(new(typeid,brandid,request1.PageSize, request1.PageIndex), cancellationToken));
    }

    private static async ValueTask<Results<Ok<GetCatalogItemsByBrandIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandId(
        [AsParameters] PaginationRequest request, 
        [FromRoute] Guid brandid,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAsync(new(brandid, request.PageSize, request.PageIndex), cancellationToken));
    }

    private static async ValueTask<Results<Ok<GetCatalogItemByIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemById(
        [FromRoute] Guid id,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemByIdAsync(new(id), cancellationToken));
    }

    private static async ValueTask<Results<Ok<PaginationResponse>, BadRequest<string>, ProblemHttpResult>> GetAllItems(
        [AsParameters] PaginationRequest request,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.PaginatedItemsAsync(request, cancellationToken));
    }
}