namespace LinkEcommerce.ServiceDefaults.Common;

public record BaseMessage
{
    protected Guid _correlacion = Guid.NewGuid();
    public Guid CorrelacionId => _correlacion; 
}