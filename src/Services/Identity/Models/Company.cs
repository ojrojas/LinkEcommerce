namespace LinkEcommerce.Services.Identity.Models;
public class Company : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
}