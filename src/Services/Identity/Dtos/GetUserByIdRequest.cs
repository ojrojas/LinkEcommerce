namespace LinkEcommerce.Services.Identity.Dtos;

public record GetUserByIdRequest(Guid id) : BaseRequest
{
    public Guid Id { get; init; } = id;
}