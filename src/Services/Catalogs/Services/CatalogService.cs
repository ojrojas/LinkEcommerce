namespace LinkEcommerce.Services.Catalogs.Services;

public class CatalogService : ICatalogService
{
    private readonly ILoggerApplicationService<CatalogService> logger;
    private readonly IGenericRepository<CatalogItem> context;

    public CatalogService(
        ILoggerApplicationService<CatalogService> logger,
        IGenericRepository<CatalogItem> context
)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async ValueTask<CreateCatalogItemResponse> CreateCatalogItemAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        CreateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Create catalog item request");
        response.CatalogItemCreated = await context.CreateAsync(request.CatalogItem, cancellationToken);
        logger.LogInformation(response, "Create catalog item successful");
        return response;
    }

    public async ValueTask<UpdateCatalogItemResponse> UpdateCatalogItemAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        UpdateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Update catalog item request");
        response.CatalogItemUpdated = await context.UpdateAsync(request.CatalogItem, cancellationToken);
        logger.LogInformation(response, "Update catalog item successful");
        return response;
    }

    public async ValueTask<DeleteCatalogItemResponse> DeleteCatalogItemAsync(DeleteCatalogItemRequest request, CancellationToken cancellationToken)
    {
        DeleteCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Delete catalog item request");
        var catalogItemToDelete = await context.GetByIdAsync(request.Id, cancellationToken);
        response.IsDeleted = await context.DeleteAsync(catalogItemToDelete, cancellationToken) != null;
        logger.LogInformation(response, "Delete catalog item successful");
        return response;
    }

    public async ValueTask<PaginationResponse> PaginatedItemsAsync(PaginationRequest request, CancellationToken cancellationToken)
    {
        PaginationResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "get catalog items by paginated request");
        var count = await context.CountAsync(cancellationToken);
        var spec = new CatalogItemSpecification(request.pageSize, request.PageIndex);
        var items = await context.ListAsync(spec, cancellationToken);
        response.PaginatedItems = new(request.PageIndex, request.pageSize, count, items);
        if (response.PaginatedItems.Count > 0)
            logger.LogInformation(response, $"Response get catalog items by paginate count: {response.PaginatedItems.Count}");
        else
            logger.LogInformation(response, "Response get catalog items by paginate no found items");

        return response;
    }

    public async ValueTask<GetCatalogItemByIdResponse> GetCatalogItemByIdAsync(GetCatalogItemByIdRequest request, CancellationToken cancellationToken)
    {
        GetCatalogItemByIdResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by id request");
        response.CatalogItem = await context.GetByIdAsync(request.Id, cancellationToken);
        logger.LogInformation(response, "Get catalogitem by id successful");

        return response;
    }

    public async ValueTask<GetCatalogItemsByBrandIdResponse> GetCatalogItemsByBrandIdAsync(PaginationByBrandIdRequest request, CancellationToken cancellationToken)
    {
        GetCatalogItemsByBrandIdResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by brand_id request");
        CatalogItemSpecification spec = new(request.pageSize, request.PageIndex, request.BrandId);
        var count = await context.CountAsync(cancellationToken);
        var items = await context.ListAsync(spec, cancellationToken);
        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.pageSize, count, items);
        logger.LogInformation(response, "Get catalogitem by brand_id successful");

        return response;
    }

    public async ValueTask<GetItemsByBrandAndTypeIdResponse> GetCatalogItemsByBrandIdAndTypeIdAsync(PaginationByBrandIdAndTypeIdRequest request, CancellationToken cancellationToken)
    {
        GetItemsByBrandAndTypeIdResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by brand_id and type_id request");
        CatalogItemSpecification spec = new(request.pageSize, request.PageIndex, request.BrandId, request.TypeId);
        var count = await context.CountAsync(cancellationToken);
        var items = await context.ListAsync(spec, cancellationToken);
        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.pageSize, count, items);
        logger.LogInformation(response, "Get catalogitem by brand_id and type_id successful");

        return response;
    }

    public async ValueTask<GetCatalogItemsByNamesResponse> GetCatalogItemByNamesAsync(PaginationByNamesRequest request, CancellationToken cancellationToken)
    {
        GetCatalogItemsByNamesResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by names request");
        CatalogItemSpecification spec = new(request.Names, request.pageSize, request.PageIndex);
        var count = await context.CountAsync(cancellationToken);
        var items = await context.ListAsync(spec, cancellationToken);
        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.pageSize, count, items);
        logger.LogInformation(response, "Get catalogitem by names successful");

        return response;
    }
}