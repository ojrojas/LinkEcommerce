namespace LinkEcommerce.Services.Catalogs.Services;

public class CatalogService : ICatalogService
{
    private readonly ILoggerApplicationService<CatalogService> logger;
    private readonly CatalogDbContext context;

    public CatalogService(
        ILoggerApplicationService<CatalogService> logger,
        CatalogDbContext context
)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        this.context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async ValueTask<CreateCatalogItemResponse> CreateCatalogItemAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        CreateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Create catalog item request");
        var entity = await context.CatalogItems.AddAsync(request.CatalogItem, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);
        response.CatalogItemCreated = entity.Entity;
        logger.LogInformation(response, "Create catalog item successful");
        return response;
    }

    public async ValueTask<UpdateCatalogItemResponse> UpdateCatalogItemAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken)
    {
        UpdateCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Update catalog item request");
        var entity = context.CatalogItems.Update(request.CatalogItem);
        await context.SaveChangesAsync(cancellationToken);
        response.CatalogItemUpdated = entity.Entity;
        logger.LogInformation(response, "Update catalog item successful");
        return response;
    }

    public async ValueTask<DeleteCatalogItemResponse> DeleteCatalogItemAsync(DeleteCatalogItemRequest request, CancellationToken cancellationToken)
    {
        DeleteCatalogItemResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Delete catalog item request");
        var catalogItemToDelete = await context.CatalogItems.FirstOrDefaultAsync(x => x.Equals(request.Id), cancellationToken);
        ArgumentNullException.ThrowIfNull(catalogItemToDelete);
        response.IsDeleted = context.CatalogItems.Remove(catalogItemToDelete) != null;
        logger.LogInformation(response, "Delete catalog item successful");
        return response;
    }

    public async ValueTask<PaginationResponse> PaginatedItemsAsync(PaginationRequest request, CancellationToken cancellationToken)
    {
        PaginationResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "get catalog items by paginated request");
        var count = await context.CatalogItems.CountAsync(cancellationToken);

        var items = context.CatalogItems.OrderBy(x => x.Name)
        .Skip(request.PageSize * request.PageIndex)
        .Take(request.PageSize);

        response.PaginatedItems = new(request.PageIndex, request.PageSize, count, items);
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
        logger.LogInformation("value::::", request.Id.ToString());
        response.CatalogItem = await context.CatalogItems.FirstOrDefaultAsync(x => x.Id.Equals(request.Id), cancellationToken);
        logger.LogInformation(response, "Get catalogitem by id successful");

        return response;
    }

    public async ValueTask<GetCatalogItemsByBrandIdResponse> GetCatalogItemsByBrandIdAsync(PaginationByBrandIdRequest request, CancellationToken cancellationToken)
    {
        GetCatalogItemsByBrandIdResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by brand_id request");
        CatalogItemSpecification spec = new(request.PageSize, request.PageIndex, request.BrandId);

        var items = context.CatalogItems.Where(x => x.CatalogBrandId.Equals(request.BrandId));
        var count = await items.CountAsync();

        var itemsOnPage = items.Skip(request.PageSize * request.PageIndex).Take(request.PageSize);

        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.PageSize, count, itemsOnPage);
        logger.LogInformation(response, "Get catalogitem by brand_id successful");

        return response;
    }

    public async ValueTask<GetItemsByBrandAndTypeIdResponse> GetCatalogItemsByBrandIdAndTypeIdAsync(PaginationByBrandIdAndTypeIdRequest request, CancellationToken cancellationToken)
    {
        GetItemsByBrandAndTypeIdResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by brand_id and type_id request");
        CatalogItemSpecification spec = new(request.PageSize, request.PageIndex, request.BrandId, request.TypeId);

        var items = context.CatalogItems.Where(x => x.CatalogBrandId.Equals(request.BrandId) && x.CatalogTypeId.Equals(request.TypeId));
        var count = await items.CountAsync();

        var itemsOnPage = items.Skip(request.PageSize * request.PageIndex).Take(request.PageSize);

        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.PageSize, count, itemsOnPage);
        logger.LogInformation(response, "Get catalogitem by brand_id and type_id successful");

        return response;
    }

    public async ValueTask<GetCatalogItemsByNamesResponse> GetCatalogItemByNamesAsync(PaginationByNamesRequest request, CancellationToken cancellationToken)
    {
        GetCatalogItemsByNamesResponse response = new(request.CorrelationId);
        logger.LogInformation(response, "Get catalog item by names request");
        CatalogItemSpecification spec = new(request.Names, request.PageSize, request.PageIndex);

        var items = context.CatalogItems.Where(x => x.Name.StartsWith(request.Names));
        var count = await items.CountAsync();

        var itemsOnPage = await items.Skip(request.PageSize * request.PageIndex)
        .Take(request.PageSize).ToListAsync();

        response.PaginatedItems = new PaginatedItems<CatalogItem>(request.PageIndex, request.PageSize, count, itemsOnPage);
        logger.LogInformation(response, "Get catalogitem by names successful");

        return response;
    }
}