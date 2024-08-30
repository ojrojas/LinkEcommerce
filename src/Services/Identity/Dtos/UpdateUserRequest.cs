namespace LinkEcommerce.Services.Identity.Dtos;

public record UpdateUserRequest: BaseRequest
{
    public required UserViewModel User { get; set; }
}