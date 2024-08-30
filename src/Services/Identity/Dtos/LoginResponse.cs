namespace LinkEcommerce.Services.Identity.Dtos;

public record LoginResponse : BaseResponse
{
    public LoginResponse(Guid correlationId) : base(correlationId)
    {

    }
    public IResult Result { get; set; }
}