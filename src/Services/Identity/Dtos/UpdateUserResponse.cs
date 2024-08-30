namespace LinkEcommerce.Services.Identity.Dtos;

public record UpdateUserResponse : BaseResponse
{
    public UpdateUserResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UserViewModel UserUpdated { get; set; }
}