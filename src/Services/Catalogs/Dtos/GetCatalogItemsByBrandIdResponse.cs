namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByBrandIdResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public PaginatedItems<CatalogItem> CatalogItems { get; set; }
}