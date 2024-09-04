namespace LinkEcommerce.Webs.LinkAdmin.Services;

public class CatalogService(HttpClient client, ILoggerApplicationService<CatalogService> logger)
{
    private readonly string CatalogUrl = "/api/catalogs";
    public async ValueTask<PaginatedItems<CatalogItem>> GetAllItemsAsync(int pageSize=10, int pageIndex=0)
    {
        var GetAllItems = $"{CatalogUrl}/getallitems?PageSize={pageSize}&PageIndex={pageIndex}";
        return await client.GetFromJsonAsync<PaginatedItems<CatalogItem>>(GetAllItems);
    }

    public async ValueTask<CatalogItem> GetByIdAsync(Guid id)
    {
        var GetById = $"{CatalogUrl}/getitembyid/{id}";
        return await client.GetFromJsonAsync<CatalogItem>(GetById);
    }

    public async Task<IEnumerable<CatalogBrand>> GetBrands()
    {
        var uri = $"{CatalogUrl}catalogBrands";
        var result = await client.GetFromJsonAsync<CatalogBrand[]>(uri);
        return result!;
    }

    public async Task<IEnumerable<CatalogType>> GetTypes()
    {
        var uri = $"{CatalogUrl}catalogTypes";
        var result = await client.GetFromJsonAsync<CatalogType[]>(uri);
        return result!;
    }
}