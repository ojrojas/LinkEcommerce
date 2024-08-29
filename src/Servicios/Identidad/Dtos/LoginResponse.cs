namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record LoginResponse : BaseResponse
{
    public LoginResponse(Guid correlacionId) : base(correlacionId)
    {

    }
    public IResult Result { get; set; }
}