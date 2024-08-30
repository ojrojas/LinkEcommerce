namespace LinkEcommerce.Services.Identity.Dtos;

public record CreateUserRequest : BaseRequest
{
    public required UserViewModel User { get; set; }
    public required SecurityRegistryUser Security { get; set; }
}