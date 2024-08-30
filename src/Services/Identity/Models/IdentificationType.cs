namespace LinkEcommerce.Services.Identity.Models;

public class IdentificationType : BaseEntity, IAggregateRoot
{
    public required string Name { get; set; }
}