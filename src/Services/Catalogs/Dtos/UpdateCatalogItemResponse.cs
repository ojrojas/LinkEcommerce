namespace LinkEcommerce.Services.Catalogs.Dtos;

public record UpdateCatalogItemResponse: BaseResponse
{
    public UpdateCatalogItemResponse(Guid correlationId): base(correlationId)
    {

    }

    public CatalogItem CatalogItemUpdated { get; set; }
}