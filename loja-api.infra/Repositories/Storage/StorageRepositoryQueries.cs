using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Storage;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Storage;

public class StorageRepositoryQueries : IStorageRepositoryQueries
{
    private readonly ContextDB _DB;


    public StorageRepositoryQueries(ContextDB dB)
    {
        _DB = dB;
    }

    public async Task<domain.Entities.Storages> GetStorageAsync(Guid id)
    {
        var Storage = await _DB.Storage.FindAsync(id);

        return Storage;
    }

    public async Task<int> GetStorageQuantityAsync(Guid IdProducts)
    {   //Faz uma busca pelo idProducts para achar todos os storage que ele possui
        var storages = await _DB.Storage.Where(s => s.IdProducts == IdProducts)
                                                                                //Pega apenas os valores de queantidade 
                                                                                .Select(q => q.Quantity)
                                                                                .ToListAsync();
        //Soma todos os valores 
        int quantity = storages.Sum();

        //Retorna a quantidade de todos os valores
        return quantity;
    }

    public async Task<IEnumerable<domain.Entities.Storages>> GetStoragesAllAsync(Guid IdProducts)
    {
        var storage = await _DB.Storage.Where(s => IdProducts == null || s.IdProducts == IdProducts).ToListAsync();

        return storage;
    }
}
