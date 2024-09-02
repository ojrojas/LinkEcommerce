namespace LinkEcommerce.Services.Basket.Models;

public class CustomerBasket : BaseEntity
{
   public Guid CustomerId { get; set; }

    public CustomerBasket(){}
    public CustomerBasket(Guid custumerId) => CustomerId = custumerId;
   
    public IList<BasketCatalogItem> CatalogItems {get;set;}= [];
}