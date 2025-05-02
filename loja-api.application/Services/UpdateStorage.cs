using System.Threading.Tasks;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces.Storage;

namespace loja_api.application.Services;

public class UpdateStorage : IUpdateStorage
{
    private readonly IStorageRepositoryQueries _queries;

    private readonly IStorageRepositoryCommands _commands;

    public UpdateStorage(IStorageRepositoryQueries queries, IStorageRepositoryCommands commands)
    {
        _queries = queries;
        _commands = commands;
    }

    public async Task UpdateValuesStorage(Guid Id, int quantity)
    {
        var Storage = await _queries.GetStorageByProducts(Id, quantity);

        Storage.Quantity -= quantity;

        await _commands.UppdateStorageAsync(Storage);
    }
}
