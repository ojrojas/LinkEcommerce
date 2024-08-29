namespace LinkEcommerce.Servicios.Identidad.Models;

public class TarjetaBancaria : BaseEntidad, IAgregadoRaiz
{
	public required string NumeroTarjeta { get; set; }
	public DateTime FechaVencimiento { get; set; }
	public TipoTarjeta TipoTarjeta { get; set; }
}

public enum TipoTarjeta
{
	Credito,
	Debito,
}