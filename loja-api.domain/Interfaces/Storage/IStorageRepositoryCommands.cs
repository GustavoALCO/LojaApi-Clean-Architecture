

using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Storage;

public interface IStorageRepositoryCommands
{
    Task CreateStorageAsync(Storages storage);

    Task DeleteStorage(Storages storage);

    Task UppdateStorageAsync(Storages storage);

}
