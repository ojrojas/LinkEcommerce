namespace LinkEcommerce.Services.Catalogs.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;
       
        builder.AddNpgsqlDbContext<CatalogDbContext>("catalogdb", configureDbContextOptions: options =>
        {
            options.UseOpenIddict();
        });

        builder.EnrichNpgsqlDbContext<CatalogDbContext>();

        services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
        services.AddAuthorization();

        IdentityModelEventSource.ShowPII = true;
     
        services.AddHttpContextAccessor();
        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
        services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddTransient<ICatalogService, CatalogService>();
    }

    public static bool IsNativeClient(this HttpContext request)
    {
        return !request.Request.RouteValues.ToString().StartsWith("https", StringComparison.Ordinal) &&
        !request.Request.RouteValues.ToString().StartsWith("http", StringComparison.Ordinal);
    }
}