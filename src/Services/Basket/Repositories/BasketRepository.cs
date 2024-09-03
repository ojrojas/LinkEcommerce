namespace LinkEcommerce.Services.Basket.Grpc;

public class BasketRepository : IBasketRepository
{
    private readonly IDatabase _database;
    private readonly ILoggerApplicationService<BasketRepository> _logger;
    private readonly IConnectionMultiplexer redis;
    private static readonly string BasketKey = nameof(BasketCatalogItem);

    public BasketRepository(ILoggerApplicationService<BasketRepository> logger, IConnectionMultiplexer redis)
    {
        _database = redis.GetDatabase();
        _logger = logger;
    }

    private static readonly RedisKey BasketKeyPrefix = BasketKey;

    private static RedisKey GetBasketKey(Guid userId)
    {
        ArgumentNullException.ThrowIfNull(userId);
        BasketKeyPrefix.Append(userId.ToString());
        return BasketKeyPrefix;
    }

    public async ValueTask<CustomerBasket?> GetCustomerBasketAsync(Guid customerId)
    {
        _logger.LogInformation("Get data info basket customer");
        using var data = await _database.StringGetLeaseAsync(GetBasketKey(customerId));

        if (data is null || data.Length == 0)
        {
            _logger.LogInformation("No data found in the database");
            return null;
        }

        _logger.LogInformation("Get data info customer basket deserialize");
        return JsonSerializer.Deserialize(data.Span, BasketSerializationContext.Default.CustomerBasket);
    }

    public async ValueTask<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket)
    {
        _logger.LogInformation("Update request data in basket");
        var json = JsonSerializer.SerializeToUtf8Bytes(basket, BasketSerializationContext.Default.CustomerBasket);
        var created = await _database.StringSetAsync(GetBasketKey(basket.CustomerId), json);

        if (!created)
        {
            _logger.LogInformation("Problem occurred persisting the item.");
            return null;
        }

        _logger.LogInformation("Basket item persisted successfully.");
        return await GetCustomerBasketAsync(basket.CustomerId);
    }

    public async Task<bool> DeleteBasketAsync(Guid customerId)
    {
        return await _database.KeyDeleteAsync(GetBasketKey(customerId));
    }
}

[JsonSerializable(typeof(CustomerBasket))]
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
public partial class BasketSerializationContext : JsonSerializerContext
{

}