namespace LinkEcommerce.ServiceDefaults.Contexts;

public interface IRepositorioGenerico<T> where T : BaseEntidad, IAgregadoRaiz
{
    public ValueTask<T> CrearAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<T> ActualizarAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<T> EliminarAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<int> ContarAsync(CancellationToken cancellationToken);
    public ValueTask<T> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken);
    public ValueTask<IEnumerable<T>> ListarAsync(CancellationToken cancellationToken);
    public ValueTask<T> PrimeroODefaultAsync(CancellationToken cancellationToken);
}