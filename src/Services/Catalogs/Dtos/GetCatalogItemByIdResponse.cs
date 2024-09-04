namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemByIdResponse : BaseResponse
{
    public GetCatalogItemByIdResponse(Guid correlationId) : base(correlationId)
    {

    }
    public CatalogItem? CatalogItem { get; set; }
}