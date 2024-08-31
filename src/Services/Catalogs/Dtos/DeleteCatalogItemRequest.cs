namespace LinkEcommerce.Services.Catalogs.Dtos;

public record DeleteCatalogItemRequest(Guid id) : BaseRequest
{
    public Guid Id { get; set; } = id;
}