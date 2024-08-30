namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemByIdResponse(Guid correlationId): BaseResponse(correlationId)
{
    public CatalogItem CatalogItem { get; set; }
}