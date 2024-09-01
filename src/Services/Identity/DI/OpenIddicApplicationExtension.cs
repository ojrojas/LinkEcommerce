namespace LinkEcommerce.Services.Identity.DI;

public static class OpenIddicApplicationExtension
{
    public static IServiceCollection AddOpenIddictApplication(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOpenIddict()
        .AddCore(config =>
        {
            config.UseEntityFrameworkCore()
            .UseDbContext<IdentityAppDbContext>();
            config.UseQuartz();
        })

        .AddServer(config =>
        {
            config.AllowPasswordFlow();
            config.AllowClientCredentialsFlow();
            config.AllowAuthorizationCodeFlow();
            config.AllowImplicitFlow();
            config.AllowRefreshTokenFlow();

            config.RequireProofKeyForCodeExchange();

            config.SetAuthorizationEndpointUris("/connect/authorize");
            config.SetIntrospectionEndpointUris("/connect/introspect");
            config.SetTokenEndpointUris("/connect/token");
            config.SetLogoutEndpointUris("/connect/logout");


            config.AddEncryptionKey(
                    new SymmetricSecurityKey(
                        Convert.FromBase64String("U3BvY2lmeTNkOWMyNzhiLTgyZDEtNGI4OC05NDRjLTg=")));

             config.AddDevelopmentSigningCertificate();

            config.UseAspNetCore()
              .DisableTransportSecurityRequirement()
              .EnableAuthorizationEndpointPassthrough()
              .EnableLogoutEndpointPassthrough()
              .EnableTokenEndpointPassthrough();
        })

        .AddValidation(config =>
        {
            config.UseLocalServer();
            config.UseAspNetCore();
        });

        return services;
    }
}