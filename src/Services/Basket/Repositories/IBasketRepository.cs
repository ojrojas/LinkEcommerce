namespace LinkEcommerce.Services.Basket.Grpc;

public interface IBasketRepository
{
    ValueTask<CustomerBasket?> GetCustomerBasketAsync(Guid customerId);
    ValueTask<CustomerBasket?> UpdateCustomerBasketAsync(CustomerBasket basket);
    Task<bool> DeleteBasketAsync(Guid customerId);
}