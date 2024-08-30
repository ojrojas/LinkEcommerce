namespace LinkEcommerce.ServiceDefaults.Contexts;

public class GenericRepository<T> :IGenericRepository<T> where T : BaseEntity, IAggregateRoot
{
    private readonly ILoggerApplicationService<GenericRepository<T>> _logger;
    private readonly DbContext _context;

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <param name="logger">logger application</param>
    /// <param name="context">context application</param>
    /// <param name="specificationEvaluator">specification evaluator</param>
    public GenericRepository(ILoggerApplicationService<GenericRepository<T>> logger, DbContext context)
    {
        _logger = logger;
        _context = context;
    }

      public async ValueTask<T> CreateAsync(T entity, CancellationToken cancellationToken)
    {
        await _context.Set<T>().AddAsync(entity, cancellationToken);
        await SaveAsync(cancellationToken);
        _logger.LogInformation($"Created entity {entity} type {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        return entity;
    }

    public async ValueTask<T> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await SaveAsync(cancellationToken);
        _logger.LogInformation($"Updated entity {entity} type {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        return entity;
    }

    private async ValueTask SaveAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync();
    }

    public async ValueTask<T> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Delete entity {entity} type {typeof(T)}, model {JsonSerializer.Serialize(entity)}");
        _context.Set<T>().Remove(entity);
        await SaveAsync(cancellationToken);
        return entity;
    }

    public async ValueTask<int> CountAsync(CancellationToken cancellationToken)
    {
        int counts = await _context.Set<T>().CountAsync();
        _logger.LogInformation(message: $"Count entities: {counts} type {typeof(T)}");
        return counts;
    }

    public async ValueTask<T> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get by id {id} type {typeof(T)}");
        return await _context.Set<T>().FindAsync(new object[] { id }, cancellationToken);
    }

    public async ValueTask<IEnumerable<T>> ListAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Get all entities type {typeof(T)}");
        return await _context.Set<T>().ToListAsync(cancellationToken);
    }

    public async ValueTask<T> FirstOrDefaultAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        return await _context.Set<T>().FirstOrDefaultAsync(cancellationToken);
    }
}