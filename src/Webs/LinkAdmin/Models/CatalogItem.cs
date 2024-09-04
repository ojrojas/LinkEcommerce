namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogItem : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CatalogBrand CatalogBrand { get; set; }
    public Guid CatalogBrandId { get; set; }
    public CatalogType CatalogType { get; set; }
    public Guid CatalogTypeId { get; set; }
    public string PictureBase64 { get; set; }
    public int AvailableQuantity { get; set; }
    public int MaxItemsInStock { get; set; }
}