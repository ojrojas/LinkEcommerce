namespace LinkEcommerce.Services.Identity.DI;

internal static class Extensions
{
    public static void AddApplicationServices(this IHostApplicationBuilder builder)
    {
        var configuration = builder.Configuration;
        var services = builder.Services;


        // Pooling is disabled because of the following error:
        // Unhandled exception. System.InvalidOperationException:
        // The DbContext of type 'OrderingContext' cannot be pooled because it does not have a public constructor accepting a single parameter of type DbContextOptions or has more than one constructor.
        builder.AddNpgsqlDbContext<IdentityAppDbContext>("identitydb", configureDbContextOptions: options =>
        {
            options.UseOpenIddict();
        });

        builder.EnrichNpgsqlDbContext<IdentityAppDbContext>();

        // Add the authentication services to DI
        services.AddIdentity<UserApplication, UserType>()
           .AddEntityFrameworkStores<IdentityAppDbContext>()
           .AddDefaultTokenProviders();

        builder.AddDefaultAuthentication();
        
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        services.AddOpenIddictApplication(configuration);

        services.AddHttpContextAccessor();
        services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
        services.AddTransient<IUserApplicationServices, UserApplicationServices>();
        services.AddTransient<SeedIdentity>(); 
    }

    public static bool IsNativeClient(this HttpContext request)
    {
        return !request.Request.RouteValues.ToString().StartsWith("https", StringComparison.Ordinal) &&
        !request.Request.RouteValues.ToString().StartsWith("http", StringComparison.Ordinal);
    }
}