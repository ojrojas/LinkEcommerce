namespace LinkEcommerce.ServiceDefaults.Contexts;

public class RepositorioGenerico<T> :IRepositorioGenerico<T> where T : BaseEntidad, IAgregadoRaiz
{
    private readonly ILoggerAplicacionService<RepositorioGenerico<T>> _logger;
    private readonly DbContext _context;

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <param name="logger">logger application</param>
    /// <param name="context">context application</param>
    /// <param name="specificationEvaluator">specification evaluator</param>
    public RepositorioGenerico(ILoggerAplicacionService<RepositorioGenerico<T>> logger, DbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async ValueTask<T> CrearAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await GuardarAsync(cancellationToken);
        _logger.LogInformation($"Crear entidad {entity} tipo {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        return entity;
    }

    public async ValueTask<T> ActualizarAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await GuardarAsync(cancellationToken);
        _logger.LogInformation($"Actualizar entidad {entity} tipo {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        return entity;
    }

    private async ValueTask GuardarAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    public async ValueTask<T> EliminarAsync(T entity, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Eliminar entidad {entity} tipo {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        _context.Set<T>().Remove(entity);
        await GuardarAsync(cancellationToken);
        return entity;
    }

    public async ValueTask<int> ContarAsync(CancellationToken cancellationToken)
    {
        int counts = await _context.Set<T>().CountAsync();
        _logger.LogInformation(message: $"conteo de entidades: {counts} tipo {typeof(T)}");
        return counts;
    }

    public async ValueTask<T> ObtenerPorIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Obtener por id {id} tipo {typeof(T)}");
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async ValueTask<IEnumerable<T>> ListarAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Obtener todas las entidades tipo {typeof(T)}");
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async ValueTask<T> PrimeroODefaultAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Especificacion model {typeof(T)}");
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }
}
