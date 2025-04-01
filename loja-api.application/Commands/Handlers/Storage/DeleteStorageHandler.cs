using loja_api.application.Commands.Storage;
using loja_api.domain.Interfaces.Storage;
using MediatR;

namespace loja_api.application.Commands.Handlers.Storage;

public class DeleteStorageHandler : IRequestHandler<DeleteStorageCommands>
{
    private readonly IStorageRepositoryQueries _storageRepositoryQueries;

    private readonly IStorageRepositoryCommands _storageRepositoryCommands;

    public DeleteStorageHandler(IStorageRepositoryCommands storageRepositoryCommands, IStorageRepositoryQueries storageRepositoryQueries)
    {
        _storageRepositoryCommands = storageRepositoryCommands;
        _storageRepositoryQueries = storageRepositoryQueries;
    }

    public async Task Handle(DeleteStorageCommands request, CancellationToken cancellationToken)
    {
        var storage = await _storageRepositoryQueries.GetStorageAsync(request.StorageId);

        if (storage == null)
            throw new Exception("Storage Não encontrada");

        await _storageRepositoryCommands.DeleteStorage(storage);
    }
}
