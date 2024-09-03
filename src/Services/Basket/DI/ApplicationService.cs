namespace LinkEcommerce.Services.Basket.DI;

public static class ApplicationServiceDependecies
{
    public static void AddApplicationService(this IHostApplicationBuilder builder)
    {
        builder.AddDefaultAuthentication();
        builder.AddRedisClient("redis");

        builder.Services.AddTransient(typeof(ILoggerApplicationService<>),typeof(LoggerApplicationService<>));
        builder.Services.AddSingleton<IBasketRepository, BasketRepository>();
    }
}