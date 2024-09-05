namespace LinkEcommerce.Services.Catalogs.Data;

public class CatalogSeed(CatalogDbContext context)
{
    public async Task SeedAsync()
    {
        await context.CatalogItems.AddRangeAsync(CatalogItemsSeed.GetCatalogItems());
        await context.SaveChangesAsync();
    }
}