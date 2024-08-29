namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record LoginRequest : BaseRequest
{
    public required string NombreUsuario { get; set; }
    public required string Contrasena { get; set; }
    public required string ReturnUrl { get; set; }
}