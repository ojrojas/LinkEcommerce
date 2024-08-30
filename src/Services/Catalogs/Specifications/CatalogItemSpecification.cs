namespace LinkEcommerce.Services.Catalogs.Specifications;

public class CatalogItemSpecification : Specification<CatalogItem>
{
    public CatalogItemSpecification(int pageSize, int pageIndex)
    {
        Query.OrderBy(x=> x.Name)
        .Skip(pageSize* pageIndex)
        .Take(pageSize);
    }
}