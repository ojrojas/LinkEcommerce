namespace LinkEcommerce.ServiceDefaults.Contexts;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IAggregateRoot
{
    private readonly ILoggerApplicationService<GenericRepository<T>> _logger;
    private readonly ISpecificationEvaluator _specificationEvaluator;
    private readonly DbContext _context;

    /// <summary>
    /// Generic Repository
    /// </summary>
    /// <param name="logger">logger application</param>
    /// <param name="context">context application</param>
    /// <param name="specificationEvaluator">specification evaluator</param>
    public GenericRepository(ILoggerApplicationService<GenericRepository<T>> logger, DbContext context, ISpecificationEvaluator specificationEvaluator)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _context = context ?? throw new ArgumentNullException(nameof(context));;
        _specificationEvaluator = specificationEvaluator ?? throw new ArgumentNullException(nameof(specificationEvaluator));;
    }

    /// <summary>
    /// Generic Repository "Service Inject"
    /// </summary>
    /// <param name="logger">logger application</param>
    /// <param name="context">context application</param>
    public GenericRepository(ILoggerApplicationService<GenericRepository<T>> logger, DbContext context) : 
        this(logger, context, AppSpecificationEvaluator.Instance) 
    { 
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

    public async ValueTask<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Specification settled {(spec)}");
        var specification = ApplySpecification(spec);
        _logger.LogInformation($"Get all entities type {typeof(T)}");
        return await specification.ToListAsync(cancellationToken);
    }

    public async ValueTask<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken)
    {
        _logger.LogInformation($"specification model {typeof(T)}");
        var spec = ApplySpecification(specification);
        return await spec.FirstOrDefaultAsync(cancellationToken) ?? null!;
    }

    /// <summary>
    /// Apply Specification search property model
    /// </summary>
    /// <param name="spec">Property model specification</param>
    /// <param name="evaluateCriteriaOnly">Evaluate only criteria false</param>
    /// <returns>IQueryable Model entity</returns>
    protected virtual IQueryable<T> ApplySpecification(ISpecification<T> spec, bool evaluateCriteriaOnly = default)
    {
        ArgumentNullException.ThrowIfNull(spec);
        _logger.LogInformation($"Query result type {typeof(T)}");
        return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), spec, evaluateCriteriaOnly);
    }

    /// <summary>
    /// Apply Specification 
    /// </summary>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="specification">specification instance model</param>
    /// <returns>IQueryable model entity</returns>
    protected virtual IQueryable<TResult> ApplySpecification<TResult>(ISpecification<T, TResult> specification)
    {
        ArgumentNullException.ThrowIfNull(specification);

        if (specification.Selector is null) throw new SelectorNotFoundException();
        _logger.LogInformation($"Query result type {typeof(T)}");

        return _specificationEvaluator.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}