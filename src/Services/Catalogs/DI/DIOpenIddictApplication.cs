namespace LinkEcommerce.Services.Catalogs.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer(configuration["IdentityApiClient"]);
                config.AddAudiences("resource_server_catalog");

                config.UseIntrospection()
                .SetClientId("catalog_api")
                .SetClientSecret("catalog_api_secret");

                config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

                // Register the System.Net.Http integration.
                config.UseSystemNetHttp();

                // Register the ASP.NET Core host.
                config.UseAspNetCore();
            });

        return services;
    }
}