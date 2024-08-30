namespace LinkEcommerce.ServiceDefaults.BaseDtos;

public record BaseMessage
{
    protected Guid _correlation = Guid.NewGuid();
    public Guid CorrelationId => _correlation; 
}