namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByNamesResponse: BaseResponse
{
    public GetCatalogItemsByNamesResponse(Guid correlationId): base(correlationId){}
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}