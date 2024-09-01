namespace LinkEcommerce.Services.Catalogs.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;

        builder.AddNpgsqlDbContext<CatalogDbContext>("catalogdb");

        builder.EnrichNpgsqlDbContext<CatalogDbContext>();

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        IdentityModelEventSource.ShowPII = true;

        services.AddHttpContextAccessor();
        services.AddScoped(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
        services.AddScoped<ICatalogService, CatalogService>();
    }
}