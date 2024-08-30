namespace LinkEcommerce.Services.Catalogs.Interfaces;

public interface ICatalogService
{
    public ValueTask<CreateCatalogItemResponse> CreateCatalogItemAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken);
    public  ValueTask<UpdateCatalogItemResponse> UpdateCatalogItemAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken);
    public  ValueTask<DeleteCatalogItemResponse> DeleteCatalogItemAsync(DeleteCatalogItemRequest request, CancellationToken cancellationToken);
    public ValueTask<PaginationResponse> PaginatedItemsAsync(PaginationRequest request, CancellationToken cancellationToken);
    public ValueTask<GetCatalogItemByIdResponse> GetCatalogItemByIdAsync(GetCatalogItemByIdRequest request, CancellationToken cancellationToken);
    public ValueTask<GetCatalogItemsByBrandIdResponse> GetCatalogItemsByBrandIdAsync(PaginationByBrandIdRequest request, CancellationToken cancellationToken);
    public ValueTask<GetItemsByBrandAndTypeIdResponse> GetCatalogItemsByBrandIdAndTypeIdAsync(PaginationByBrandIdAndTypeIdRequest request, CancellationToken cancellationToken);
    public ValueTask<GetCatalogItemsByNamesResponse> GetCatalogItemByNamesAsync(PaginationByNamesRequest request, CancellationToken cancellationToken);
}