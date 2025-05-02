using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Storage;

public interface IStorageRepositoryQueries
{
    Task<Storages> GetStorageAsync(Guid id);

    Task<IEnumerable<Storages>> GetStoragesAllAsync();

    Task<int> GetStorageQuantityAsync(Guid IdProducts);

    Task<domain.Entities.Storages> GetStorageByProducts(Guid Idproducts, int quantity);
}
