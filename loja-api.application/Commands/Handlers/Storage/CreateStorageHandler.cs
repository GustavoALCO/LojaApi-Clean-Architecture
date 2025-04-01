using AutoMapper;
using loja_api.application.Commands.Storage;
using loja_api.domain.Interfaces.Storage;
using loja_api.domain.Entities;
using MediatR;

namespace loja_api.application.Commands.Handlers.Storage;

public class CreateStorageHandler : IRequestHandler<CreateStorageCommands>
{
    private readonly IStorageRepositoryCommands _storageRepositoryCommands;

    private readonly IMapper _mapper;

    public CreateStorageHandler(IStorageRepositoryCommands storageRepositoryCommands, IMapper mapper)
    {
        _storageRepositoryCommands = storageRepositoryCommands;
        _mapper = mapper;
    }


    public async Task Handle(CreateStorageCommands request, CancellationToken cancellationToken)
    {
        var storage = _mapper.Map<Storages>(request.StorageCreateDTO);

        await _storageRepositoryCommands.CreateStorageAsync(storage);
    }
}
