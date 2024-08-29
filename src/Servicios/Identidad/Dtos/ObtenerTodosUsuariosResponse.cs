namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record ObtenerTodosUsuariosResponse : BaseResponse
{
    public ObtenerTodosUsuariosResponse(Guid correlacionId) : base(correlacionId)
    {

    }

    public IEnumerable<UsuarioViewModel> Usuarios { get; set; }
}