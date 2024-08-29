namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record ActualizarUsuarioRequest: BaseRequest
{
    public required UsuarioViewModel Usuario { get; set; }
}