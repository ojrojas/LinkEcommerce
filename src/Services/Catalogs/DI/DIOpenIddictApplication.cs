namespace LinkEcommerce.Services.Catalogs.DI;

public static class DIOpenIddictApplication
{
    public static IServiceCollection AddDIOpenIddictApplication(this IServiceCollection services)
    {
        services.AddOpenIddict()
            .AddValidation(config =>
            {
                config.SetIssuer("http://docker.for.mac.localhost:5005/");
                config.AddAudiences("resource_catalogs");

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