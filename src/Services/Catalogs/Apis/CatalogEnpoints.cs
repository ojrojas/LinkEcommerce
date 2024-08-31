
namespace LinkEcommerce.Services.Catalogs.Apis;

public static class CatalogsEndpoint
{
    public static RouteGroupBuilder MapCatalogEndpointsV1(this IEndpointRouteBuilder routeBuilder)
    {
        var api = routeBuilder.MapGroup(string.Empty).HasApiVersion(1.0);

        // api.MapGet("/getallitems", GetAllItems);
        // api.MapGet("/getitembyid/{id:guid}", GetItemById);
        // api.MapGet("/getitemsbybrandid/{brandid:guid}", GetItemsByBrandId);
        // api.MapGet("/getitemsbybrandidandtypeid/brand/{brandid:guid}/type/{typeid:guid}", GetItemsByBrandIdAndTypeId);
        api.MapGet("/getitemsbynames/pagesize/{pagesize:int}/pageindex/{pageindex:int}/names/{names}", GetItemsByNames);

        api.MapPost("/create", CreateCatalogItem);
        api.MapPatch("/update", UpdateCatalogItem);
        api.MapDelete("/delete/{id:guid}", DeleteCatalogItem);
        return api;

    }

    public static async ValueTask<Results<Ok<DeleteCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> DeleteCatalogItem(
        [FromRoute] Guid id,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.DeleteCatalogItemAsync(new(id), cancellationToken));
    }

    public static async ValueTask<Results<Ok<UpdateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> UpdateCatalogItem(
        [FromBody] UpdateCatalogItemRequest request, 
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.UpdateCatalogItemAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<CreateCatalogItemResponse>, BadRequest<string>, ProblemHttpResult>> CreateCatalogItem(
        [FromBody] CreateCatalogItemRequest request, 
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken
    )
    {
        return TypedResults.Ok(await service.CreateCatalogItemAsync(request, cancellationToken));
    }

    public static async ValueTask<Results<Ok<GetCatalogItemsByNamesResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByNames(
        [FromRoute] int pagesize, [FromRoute]int pageindex, [FromRoute]string names,
        [FromServices] ICatalogService service,
        CancellationToken cancellationToken)
    {
        return TypedResults.Ok(await service.GetCatalogItemByNamesAsync(new(names, pagesize, pageindex), cancellationToken));
    }

    // public static async ValueTask<Results<Ok<GetItemsByBrandAndTypeIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandIdAndTypeId(
    //     [FromRoute] PaginationByBrandIdAndTypeIdRequest request,
    //     [FromServices] ICatalogService service,
    //     CancellationToken cancellationToken)
    // {
    //     return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAndTypeIdAsync(request, cancellationToken));
    // }

    // public static async ValueTask<Results<Ok<GetCatalogItemsByBrandIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemsByBrandId(
    //     [FromRoute] PaginationByBrandIdRequest request,
    //     [FromServices] ICatalogService service,
    //     CancellationToken cancellationToken)
    // {
    //     return TypedResults.Ok(await service.GetCatalogItemsByBrandIdAsync(request, cancellationToken));
    // }

    // public static async ValueTask<Results<Ok<GetCatalogItemByIdResponse>, BadRequest<string>, ProblemHttpResult>> GetItemById(
    //     [FromRoute] GetCatalogItemByIdRequest request,
    //     [FromServices] ICatalogService service,
    //     CancellationToken cancellationToken)
    // {
    //     return TypedResults.Ok(await service.GetCatalogItemByIdAsync(request, cancellationToken));
    // }

    // public static async ValueTask<Results<Ok<PaginationResponse>, BadRequest<string>, ProblemHttpResult>> GetAllItems(
    //     [FromRoute] PaginationRequest request,
    //     [FromServices] ICatalogService service,
    //     CancellationToken cancellationToken
    // )
    // {
    //     return TypedResults.Ok(await service.PaginatedItemsAsync(request, cancellationToken));
    // }
}