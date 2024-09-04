namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByBrandIdResponse : BaseResponse
{
    public GetCatalogItemsByBrandIdResponse(Guid correlationId) : base(correlationId) { }
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}