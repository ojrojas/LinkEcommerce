namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemByIdRequest(Guid Id) : BaseRequest
{
    public Guid Id { get; set; } = Id;
}