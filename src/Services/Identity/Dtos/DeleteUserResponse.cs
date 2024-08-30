namespace LinkEcommerce.Services.Identity.Dtos;

public record DeleteUserResponse : BaseResponse
{
    public DeleteUserResponse(Guid correlationId) : base(correlationId)
    {
    }

    public bool UserDeleted { get; set; }
}