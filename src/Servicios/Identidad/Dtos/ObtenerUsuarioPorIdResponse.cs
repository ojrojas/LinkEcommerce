namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record ObtenerUsuarioPorIdResponse : BaseResponse
{
    public ObtenerUsuarioPorIdResponse(Guid correlacionId) : base(correlacionId)
    {

    }

    public UsuarioViewModel? UsuarioViewModel { get; set;}
    public IList<string> TipoUsuario;
}