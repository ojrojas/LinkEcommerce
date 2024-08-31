
namespace LinkEcommerce.Services.Catalogs.Services;

public class CatalogService2: ICatalogService2
{
    private readonly CatalogDbContext context;
    private readonly ILoggerApplicationService<CatalogService2> logger;

    public CatalogService2(ILoggerApplicationService<CatalogService2> logger, CatalogDbContext context)
    {
        this.logger = logger;
        this.context = context;
    }

    public async ValueTask<string> HelloAsync(CancellationToken cancellationToken)
    {
        this.logger.LogInformation("Hello World works");

        var content = await this.context.CatalogItems.ToListAsync(cancellationToken);

        await Task.CompletedTask;
        return $"Hello from services {content.Select(x=> x.Name)}";
    }
}