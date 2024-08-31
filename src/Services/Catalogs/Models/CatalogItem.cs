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

    /// <summary>
    /// Add items to stock
    /// </summary>
    /// <param name="quantity">Quantity items to add</param>
    /// <returns>Quantities added</returns>
    public ReturnQuantity AddItems(int quantity)
    {
        int stock = this.AvailableQuantity;
        if ((this.AvailableQuantity + quantity) > this.AvailableQuantity)
            this.AvailableQuantity += (this.MaxItemsInStock - this.AvailableQuantity);
        else
            this.AvailableQuantity += quantity;

        return new(this.AvailableQuantity - stock, "Quantity items added");
    }

    /// <summary>
    /// Removed items to stock
    /// </summary>
    /// <param name="quantity">Quantities Removed</param>
    /// <returns></returns>
    public ReturnQuantity RemoveItems(int quantity)
    {
        if (AvailableQuantity.Equals(default))
            throw new CatalogItemNotAvailableException($"stock items name: {Name}, is all sold out");

        if (quantity <= 0)
            throw new CatalogItemNotAvailableException($"Item should be greater than zero units");

        var removed = this.AvailableQuantity -= quantity;

        return new(removed, "Quantity items removed");
    }
}

public class ReturnQuantity(int quantity, string description)
{
    public int Quantity { get; set; } = quantity;
    public string Description { get; set; } = description;
}