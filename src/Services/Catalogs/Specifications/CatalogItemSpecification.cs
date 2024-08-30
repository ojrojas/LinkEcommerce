namespace LinkEcommerce.Services.Catalogs.Specifications;

public class CatalogItemSpecification : Specification<CatalogItem>
{
    public CatalogItemSpecification(int pageSize, int pageIndex)
    {
        Query.OrderBy(x=> x.Name)
        .Skip(pageSize* pageIndex)
        .Take(pageSize);
    }

    public CatalogItemSpecification(string name, int pageSize, int pageIndex)
    {
        Query.Where(x=> x.Name.StartsWith(name))
        .Skip(pageSize* pageIndex)
        .Take(pageSize);
    }

    public CatalogItemSpecification(int pageSize, int pageIndex,Guid branId)
    {
        Query.Include(b=> b.CatalogBrand)
        .Where(c=> c.CatalogBrandId.Equals(branId))
        .Skip(pageSize* pageIndex)
        .Take(pageSize);
    }

    public CatalogItemSpecification(int pageSize, int pageIndex,Guid branId, Guid typeId)
    {
        Query.Include(b=> b.CatalogBrand)
        .Where(c=> c.CatalogBrandId.Equals(branId) && c.CatalogTypeId.Equals(typeId))
        .Skip(pageSize* pageIndex)
        .Take(pageSize);
    }
}