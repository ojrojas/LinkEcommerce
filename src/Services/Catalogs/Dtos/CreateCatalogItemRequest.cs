namespace LinkEcommerce.Services.Catalogs.Dtos;

public record CreateCatalogItemRequest : BaseRequest
{
    public required CatalogItem CatalogItem { get; set; }
}