namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogBrand : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
}