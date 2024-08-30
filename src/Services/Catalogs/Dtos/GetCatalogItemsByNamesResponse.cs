namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByNamesResponse(Guid correlationId): BaseResponse(correlationId)
{
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}