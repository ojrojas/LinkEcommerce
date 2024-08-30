namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByNamesRequest: BaseRequest
{
    public required string Names { get; set; }
}