using Microsoft.IdentityModel.JsonWebTokens;
using OpenIddict.Validation.AspNetCore;

namespace LinkEcommerce.Webs.LinkAdmin.Extensions;

public static class ServiceApplicationExtension
{
    public static void AddServiceApplications(this IHostApplicationBuilder builder, IConfiguration configuration)
    {
        // var services = builder.Services;

        // var identityUrl = configuration.GetRequiredValue("IdentityUrl");
        // var callBackUrl = configuration.GetRequiredValue("CallBackUrl");
        // var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);

        // HTTP and GRPC client registrations
        builder.Services.AddGrpcClient<Basket.BasketClient>(o => o.Address = new("http://basket-ecommerce"))
            .AddAuthToken();

        builder.Services.AddHttpClient<CatalogService>(o => o.BaseAddress = new("http://catalogs-ecommerce"))
            .AddApiVersion(1.0)
            .AddAuthToken();

        builder.Services.AddHttpClient<OrderService>(o => o.BaseAddress = new("http://orders-ecommerce"))
            .AddApiVersion(1.0)
            .AddAuthToken();

        builder.Services.AddAuthorization();
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme;
        })
        .AddCookie();

        builder.Services.AddTransient(typeof(ILoggerApplicationService<>), typeof(LoggerApplicationService<>));
    }
}