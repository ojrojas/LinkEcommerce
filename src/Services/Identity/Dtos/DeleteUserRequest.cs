namespace LinkEcommerce.Services.Identity.Dtos;

public record DeleteUserRequest : BaseRequest
{
    public Guid Id { get; set; }
}