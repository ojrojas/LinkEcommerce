namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record CrearUsuarioResponse: BaseResponse
{
    public CrearUsuarioResponse(Guid correlacionId) : base(correlacionId)
    {
    }

    public UsuarioViewModel UsuarioCreado { get; set; }
}