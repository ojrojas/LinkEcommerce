namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public required string Name {get;set;}
}