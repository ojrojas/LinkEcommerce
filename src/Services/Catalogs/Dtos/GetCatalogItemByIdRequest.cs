namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemByIdRequest: BaseRequest
{
    public Guid Id { get; set; }
}