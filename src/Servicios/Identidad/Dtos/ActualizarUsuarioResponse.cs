namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record ActualizarUsuarioResponse : BaseResponse
{
    public ActualizarUsuarioResponse(Guid correlacionId) : base(correlacionId)
    {
    }

    public UsuarioViewModel UsuarioActualizado { get; set; }
}