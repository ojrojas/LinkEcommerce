namespace LinkEcommerce.ServiceDefaults.Common;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlacion) : base()
    {
        _correlacion = correlacion;
    }
}