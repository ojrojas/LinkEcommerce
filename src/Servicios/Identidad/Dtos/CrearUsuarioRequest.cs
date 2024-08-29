namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record CrearUsuarioRequest : BaseRequest
{
    public UsuarioViewModel Usuario { get; set; }
    public RegistroSeguridadUsuario Seguridad { get; set; }
}