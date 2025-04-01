using AutoMapper;
using loja_api.application.Commands.Storage;
using loja_api.domain.Interfaces.Storage;
using MediatR;

namespace loja_api.application.Commands.Handlers.Storage;

public class UpdateStorageHandler : IRequestHandler<UpdateStorageCommands>
{
    private readonly IStorageRepositoryCommands _storageRepositoryCommands;

    private readonly IStorageRepositoryQueries _storageRepositoryQueries;


    public UpdateStorageHandler(IStorageRepositoryQueries storageRepositoryQueries, IStorageRepositoryCommands storageRepositoryCommands)
    {
        _storageRepositoryQueries = storageRepositoryQueries;
        _storageRepositoryCommands = storageRepositoryCommands;
    }

    public async Task Handle(UpdateStorageCommands request, CancellationToken cancellationToken)
    {
        var products = await _storageRepositoryQueries.GetStorageAsync(request.StorageUpdateDTO.IdStorage);

        if (products == null)
            throw new Exception("Não Foi Possivel encontrar o produto");

        await _storageRepositoryCommands.UppdateStorageAsync(products);
    }
}
