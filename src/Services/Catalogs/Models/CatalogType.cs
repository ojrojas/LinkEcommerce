namespace LinkEcommerce.Services.Catalogs.Models;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public string Name {get;set;}
}