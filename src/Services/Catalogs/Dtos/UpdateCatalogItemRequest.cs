namespace LinkEcommerce.Services.Catalogs.Dtos;

public record UpdateCatalogItemRequest: BaseRequest
{
    public CatalogItem CatalogItem {get;set;}
}