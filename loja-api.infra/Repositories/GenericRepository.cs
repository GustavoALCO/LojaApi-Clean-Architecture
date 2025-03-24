using loja_api.domain.Entities;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;
using loja_api.domain.Interfaces;

namespace loja_api.infra.Repositories;

internal class GenericRepository<T> : IRepository<T> where T : class
{
    private readonly ContextDB _DB;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(ContextDB dB)
    {
        _DB = dB;
        _dbSet = _DB.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _DB.SaveChangesAsync();
    }

    public async Task DeleteAsync(object id)
    {
        var generic = await _dbSet.FindAsync(id);

        if (generic != null)
        {
            _dbSet.Remove(generic);
            await _DB.SaveChangesAsync();
        }
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await _dbSet.FindAsync(id);  
    }

    public async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _DB.SaveChangesAsync();
    }
}
