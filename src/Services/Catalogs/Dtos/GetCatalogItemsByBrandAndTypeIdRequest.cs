namespace LinkEcommerce.Services.Catalogs.Dtos;

public record GetItemsByBrandAndTypeIdRequest: BaseRequest
{
    public Guid BrandId { get; set; }
    public Guid TypeId { get; set; }
}