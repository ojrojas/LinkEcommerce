namespace LinkEcommerce.Servicios.Identidad.Models;

public record UsuarioViewModel
{
    public Guid Id { get; set; }
    public required string Nombre { get; set; }
    public string? SegundoNombre { get; set; }
    public required string Apellido { get; set; }
    public string? SegundoApellido { get; set; }
    public required TipoIdentificacion TipoIdentificacion { get; set; }
    public Guid TipoIdentificacionId { get; set; }
    public required string Identificacion { get; set; }
    public DateTime FechaNacimiento { get; set; }
    public required string Direccion { get; set; }
    public required string Contacto { get; set; }
    public TarjetaBancaria TarjetaBancaria { get; set; }
    public Guid TarjetaBancariaId { get; set; }
    public Compania Compania { get; set; }
    public Guid CompaniaId { get; set; }
}

public record RegistroSeguridadUsuario
{
    public required string Contrasena { get; set; }
    public required string ContrasenaConfirmada { get; set; }
    public bool IsConFirmedPassword => Contrasena.Equals(ContrasenaConfirmada);
}