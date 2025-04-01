using loja_api.domain.Interfaces.Storage;
using loja_api.infra.Context;

namespace loja_api.infra.Repositories.Storages;

public class StorageRepositoryCommands : IStorageRepositoryCommands
{
    private readonly ContextDB _db;

    public StorageRepositoryCommands(ContextDB db)
    {
        _db = db;
    }

    public async Task CreateStorageAsync(domain.Entities.Storages storage)
    {
        await _db.Storage.AddAsync(storage);

        await _db.SaveChangesAsync();
    }

    public Task DeleteStorage(domain.Entities.Storages storage)
    {
        _db.Storage.Remove(storage);

        _db.SaveChanges();

        return Task.CompletedTask;
    }

    public async Task UppdateStorageAsync(domain.Entities.Storages storage)
    {
        _db.Storage.Update(storage);

        await _db.SaveChangesAsync();
    }
}
