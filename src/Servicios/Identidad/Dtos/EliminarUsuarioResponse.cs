namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record EliminarUsuarioResponse : BaseResponse
{
    public EliminarUsuarioResponse(Guid correlacionId) : base(correlacionId)
    {
    }

    public bool EstaEliminado { get; set; }
}