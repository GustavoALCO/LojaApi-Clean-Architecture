namespace loja_api.application.Interfaces;

public interface IGenericService<TDTO, TEntity> where TEntity : class
{
    Task<TDTO> GetByIdAsync(object id);

    Task AddAsync(TDTO entity);

    Task UpdateAsync(TDTO entity);

    Task DeleteAsync(object id);
}
