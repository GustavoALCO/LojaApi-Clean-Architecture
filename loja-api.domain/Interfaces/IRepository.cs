namespace loja_api.domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(object id);

    Task AddAsync(T entity);

    Task UpdateAsync(T entity);

    Task DeleteAsync(object id);
}