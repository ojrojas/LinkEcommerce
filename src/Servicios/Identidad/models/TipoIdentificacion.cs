namespace LinkEcommerce.Servicios.Identidad.Models;


public class TipoIdentificacion : BaseEntidad, IAgregadoRaiz
{
    public required string Name { get; set; }
}