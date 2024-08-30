namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetItemsByBrandAndTypeIdResponse(Guid correlationId): BaseResponse(correlationId)
{
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}