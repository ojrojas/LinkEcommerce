namespace LinkEcommerce.Services.Basket.Grpc;

public class BaseService(ILoggerApplicationService<BaseService> logger, IBasketRepository basketRepository) : Basket.BasketBase
{
    [AllowAnonymous]
    public override async Task<CustomerBasketResponse> GetBasket(GetBasketRequest request, ServerCallContext context)
    {
        var customerId = context.GetUserIdentity();
        if (string.IsNullOrEmpty(customerId))
        {
            return new();
        }

        if (logger.FeaturesLogger().IsEnabled(LogLevel.Debug))
        {
            logger.FeaturesLogger().LogDebug("Begin GetBasketById call from method {Method} for basket id {Id}", context.Method, customerId);
        }

        var data = await basketRepository.GetCustomerBasketAsync(Guid.Parse(customerId));

        if (data is not null)
        {
            return RemapedToCustomerBasketResponse(data);
        }

        return new();
    }

      public override async Task<CustomerBasketResponse> UpdateBasket(UpdateBasketRequest request, ServerCallContext context)
    {
        var userId = context.GetUserIdentity();
        if (string.IsNullOrEmpty(userId))
        {
            ThrowNotAuthenticated();
        }

        if (logger.FeaturesLogger().IsEnabled(LogLevel.Debug))
        {
            logger.FeaturesLogger().LogDebug("Begin UpdateBasket call from method {Method} for basket id {Id}", context.Method, userId);
        }

        var customerBasket = RemapedToCustomerBasketForUpdate(userId, request);
        var response = await basketRepository.UpdateCustomerBasketAsync(customerBasket);
        if (response is null)
        {
            ThrowBasketDoesNotExist(userId);
        }

        return RemapedToCustomerBasketResponse(response);
    }

    public override async Task<DeleteBasketResponse> DeleteBasket(DeleteBasketRequest request, ServerCallContext context)
    {
        var userId = context.GetUserIdentity();
        if (string.IsNullOrEmpty(userId))
        {
            ThrowNotAuthenticated();
        }

        await basketRepository.DeleteBasketAsync(Guid.Parse(userId));
        return new();
    }

    [DoesNotReturn]
    private static void ThrowNotAuthenticated() => throw new RpcException(new Status(StatusCode.Unauthenticated, "The caller is not authenticated."));

    [DoesNotReturn]
    private static void ThrowBasketDoesNotExist(string userId) => throw new RpcException(new Status(StatusCode.NotFound, $"Basket with buyer id {userId} does not exist"));


    private static CustomerBasketResponse RemapedToCustomerBasketResponse(CustomerBasket customerBasket)
    {
        CustomerBasketResponse response = new();

        foreach (var catalogItem in customerBasket.CatalogItems)
        {
            response.Catalogitems.Add(new BasketCatalogItem()
            {
                CatalogitemId = catalogItem.CatalogItemId,
                Quantity = catalogItem.Quantity,
            });
        }

        return response;
    }

    private static CustomerBasket RemapedToCustomerBasketForUpdate(string userId, UpdateBasketRequest customerBasketRequest)
    {
        CustomerBasket response = new(Guid.Parse(userId)); 

        foreach (var item in customerBasketRequest.Catalogitems)
        {
            response.CatalogItems.Add(new()
            {
                CatalogItemId = item.CatalogitemId,
                Quantity = item.Quantity,
            });
        }

        return response;
    }
}