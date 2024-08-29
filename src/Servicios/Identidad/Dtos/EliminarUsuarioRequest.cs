namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record EliminarUsuarioRequest : BaseRequest
{
    public Guid Id { get; set; }
}