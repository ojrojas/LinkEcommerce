namespace LinkEcommerce.Services.Basket.Models;

public class Customer : BaseEntity
{
   public Guid CustomerId { get; set; }

    public Customer(){}
    public Customer(Guid custumerId) => CustomerId = custumerId;
}