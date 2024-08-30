namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetCatalogItemsByBrandIdRequest: BaseRequest
{
    public Guid Id { get; set; }
    public PaginationRequest request { get; set; }
}