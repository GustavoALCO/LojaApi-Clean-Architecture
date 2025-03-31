using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Storages;

public interface IStorageRepositoryCommands
{
    Task CreateStorageAsync(Storage storage);

    Task DeleteStorage(Guid id);

    Task UppdateStorageAsync(Storage storage);

}
