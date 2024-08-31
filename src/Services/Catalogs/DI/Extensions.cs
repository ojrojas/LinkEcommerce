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
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<ICatalogService, CatalogService>();
    }

    public static bool IsNativeClient(this HttpContext request)
    {
        return !request.Request.RouteValues.ToString().StartsWith("https", StringComparison.Ordinal) &&
        !request.Request.RouteValues.ToString().StartsWith("http", StringComparison.Ordinal);
    }
}