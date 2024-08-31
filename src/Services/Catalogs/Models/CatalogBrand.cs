namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogBrand : BaseEntity, IAggregateRoot
{
    public string Name { get; set; }
}