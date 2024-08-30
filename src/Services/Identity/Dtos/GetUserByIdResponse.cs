namespace LinkEcommerce.Services.Identity.Dtos;

public record GetUserByIdResponse : BaseResponse
{
    public GetUserByIdResponse(Guid correlationId) : base(correlationId)
    {

    }

    public UserViewModel? User { get; set;}
    public IList<string> UserTypes;
}