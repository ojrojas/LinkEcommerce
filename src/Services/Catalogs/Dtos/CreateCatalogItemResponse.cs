namespace LinkEcommerce.Services.Catalogs.Dtos;

public record CreateCatalogItemResponse : BaseResponse
{
    public CreateCatalogItemResponse(Guid correlationId) : base(correlationId)
    {

    }
    public CatalogItem CatalogItemCreated { get; set; }
}