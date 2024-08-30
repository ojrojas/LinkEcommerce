namespace LinkEcommerce.Services.Catalogs.Dtos;

public record DeleteCatalogItemRequest : BaseRequest
{
    public Guid Id { get; set; }
}