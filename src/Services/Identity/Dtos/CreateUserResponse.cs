namespace LinkEcommerce.Services.Identity.Dtos;

public record CreateUserResponse: BaseResponse
{
    public CreateUserResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UserViewModel UserCreated { get; set; }
}