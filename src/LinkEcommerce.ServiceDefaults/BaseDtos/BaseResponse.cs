namespace LinkEcommerce.ServiceDefaults.BaseDtos;

public record BaseResponse : BaseMessage
{
    public BaseResponse(Guid correlation) : base()
    {
        _correlation = correlation;
    }
}