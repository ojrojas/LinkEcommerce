namespace LinkEcommerce.Services.Catalogs.Services;

public class CatalogService(
    ILoggerApplicationService<CatalogService> logger,
    IGenericRepository<CatalogItem> context
) : ICatalogService
{
    public async ValueTask<CreateCatalogItemResponse> CreateCatalogItemAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        CreateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Create catalog item request");
        response.CatalogItemCreated =  await context.CreateAsync(request.CatalogItem, cancellationToken);
        logger.LogInformation(response, "Create catalog item successful");
        return response;
    }

    public async ValueTask<UpdateCatalogItemResponse> UpdateCatalogItemAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        UpdateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Update catalog item request");
        response.CatalogItemUpdated =  await context.UpdateAsync(request.CatalogItem, cancellationToken);
        logger.LogInformation(response, "Update catalog item successful");
        return response;
    }

    public async ValueTask<DeleteCatalogItemResponse> DeleteCatalogItemAsync(DeleteCatalogItemRequest request, CancellationToken cancellationToken)
    {
        DeleteCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Delete catalog item request");
        var catalogItemToDelete = await context.GetByIdAsync(request.Id, cancellationToken);
        response.IsDeleted =  await context.DeleteAsync(catalogItemToDelete, cancellationToken) != null;        
        logger.LogInformation(response, "Delete catalog item successful");
        return response;
    }

    public async ValueTask<PaginationResponse> PaginatedItemsAsync(PaginationRequest request, CancellationToken cancellationToken)
    {
        PaginationResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "get catalog items by paginated request");
        var count = await context.CountAsync(cancellationToken);
        var spec = new CatalogItemSpecification(request.pageSize, request.PageIndex);
        var items = await context.ListAsync(spec,cancellationToken);
        response.PaginatedItems = new (request.PageIndex, request.pageSize, count, items);
        return response;
    }


}