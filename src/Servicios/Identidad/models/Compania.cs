namespace LinkEcommerce.Servicios.Identidad.Models;

public class Compania : BaseEntidad, IAgregadoRaiz
{
    public required string Nombre { get; set; }
}