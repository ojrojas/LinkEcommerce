namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByBrandIdResponse(Guid correlationId) : BaseResponse(correlationId)
{
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}