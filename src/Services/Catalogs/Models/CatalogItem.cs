namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogItem : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public CatalogBrand CatalogBrand { get; set; }
    public Guid CatalogBrandId { get; set; }
    public CatalogType CatalogType { get; set; }
    public Guid CatalogTypeId { get; set; }
    public string PictureBase64 { get; set; }
    public int AvailableQuantity { get; set; }
    public int MaxItemsInStock { get; set; }

    /// <summary>
    /// Add items to stock
    /// </summary>
    /// <param name="quantity">Quantity items to add</param>
    /// <returns>Quantities added</returns>
    public (int, string) AddItems(int quantity)
    {
        int stock = this.AvailableQuantity;
        if ((this.AvailableQuantity + quantity) > this.AvailableQuantity)
            this.AvailableQuantity += (this.MaxItemsInStock - this.AvailableQuantity);
        else
            this.AvailableQuantity += quantity;

        return (this.AvailableQuantity - stock, "Quantity items added");
    }

    /// <summary>
    /// Removed items to stock
    /// </summary>
    /// <param name="quantity">Quantities Removed</param>
    /// <returns></returns>
    public (int, string) RemoveItems(int quantity)
    {
        if(AvailableQuantity.Equals(default))
            throw new CatalogItemNotAvailableException($"stock items name: {Name}, is all sold out");
        
        if(quantity <= 0)
            throw new CatalogItemNotAvailableException($"Item should be greater than zero units");
         
        var removed = this.AvailableQuantity -= quantity;

        return (removed, "Quantity items removed");
    }
}