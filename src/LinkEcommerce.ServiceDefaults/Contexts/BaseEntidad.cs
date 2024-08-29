namespace LinkEcommerce.ServiceDefaults.Contexts;

public class BaseEntidad
{
    protected Guid  Id {get;set;}
    public Guid CreadoPor { get; set; }
    public DateTimeOffset FechaCreacion { get; set; }
    public Guid? ModificadoPor { get; set; }
    public DateTimeOffset? FechaModificacion { get; set; }
    public bool Estado { get; set; }
}