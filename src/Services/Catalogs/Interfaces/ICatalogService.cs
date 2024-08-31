namespace LinkEcommerce.Services.Catalogs.Interfaces;

public interface ICatalogService
{
    ValueTask<CreateCatalogItemResponse> CreateCatalogItemAsync(CreateCatalogItemRequest request, CancellationToken cancellationToken);
    ValueTask<UpdateCatalogItemResponse> UpdateCatalogItemAsync(UpdateCatalogItemRequest request, CancellationToken cancellationToken);
    ValueTask<DeleteCatalogItemResponse> DeleteCatalogItemAsync(DeleteCatalogItemRequest request, CancellationToken cancellationToken);
    ValueTask<PaginationResponse> PaginatedItemsAsync(PaginationRequest request, CancellationToken cancellationToken);
    ValueTask<GetCatalogItemByIdResponse> GetCatalogItemByIdAsync(GetCatalogItemByIdRequest request, CancellationToken cancellationToken);
    ValueTask<GetCatalogItemsByBrandIdResponse> GetCatalogItemsByBrandIdAsync(PaginationByBrandIdRequest request, CancellationToken cancellationToken);
    ValueTask<GetItemsByBrandAndTypeIdResponse> GetCatalogItemsByBrandIdAndTypeIdAsync(PaginationByBrandIdAndTypeIdRequest request, CancellationToken cancellationToken);
    ValueTask<GetCatalogItemsByNamesResponse> GetCatalogItemByNamesAsync(PaginationByNamesRequest request, CancellationToken cancellationToken);
}