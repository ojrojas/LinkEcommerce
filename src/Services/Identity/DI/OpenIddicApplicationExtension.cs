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
            config.AllowImplicitFlow();
            config.AllowRefreshTokenFlow();

            config.RequireProofKeyForCodeExchange();

            config.SetTokenEndpointUris("connect/token");
            config.SetAuthorizationEndpointUris("connect/authorize");
            // config.SetLogoutEndpointUris("connect/logout");

#if DEBUG
            config.AddDevelopmentEncryptionCertificate()
            .AddDevelopmentSigningCertificate();
#else
            config.AddEphemeralEncryptionKey()
            .AddEphemeralSigningKey();
#endif
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