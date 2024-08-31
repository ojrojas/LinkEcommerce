namespace LinkEcommerce.ServiceDefaults.Contexts;

public interface IGenericRepository<T> where T : class, IAggregateRoot
{
    public ValueTask<T> CreateAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<T> UpdateAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<T> DeleteAsync(T entity, CancellationToken cancellationToken);
    public ValueTask<int> CountAsync(CancellationToken cancellationToken);
    public ValueTask<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public ValueTask<IEnumerable<T>> ListAsync(CancellationToken cancellationToken);
    public ValueTask<T> FirstOrDefaultAsync(CancellationToken cancellationToken);
    public ValueTask<IEnumerable<T>> ListAsync(ISpecification<T> spec, CancellationToken cancellationToken);
    public ValueTask<T> FirstOrDefaultAsync(ISpecification<T> specification, CancellationToken cancellationToken);
}