namespace LinkEcommerce.Servicios.Identidad.Dtos;

public record ObtenerUsuarioPorIdRequest: BaseRequest
{
    public Guid Id {get;set;}
}