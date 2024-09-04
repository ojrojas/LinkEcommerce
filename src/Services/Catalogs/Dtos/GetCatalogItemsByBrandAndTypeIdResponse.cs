namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetItemsByBrandAndTypeIdResponse: BaseResponse
{
    public GetItemsByBrandAndTypeIdResponse(Guid correlationId): base(correlationId)
    {
        
    }
    public PaginatedItems<CatalogItem> PaginatedItems { get; set; }
}