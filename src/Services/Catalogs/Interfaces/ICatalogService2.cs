namespace LinkEcommerce.Services.Catalogs.Interfaces;

public interface ICatalogService2
{
    ValueTask<string> HelloAsync(CancellationToken cancellationToken);
}