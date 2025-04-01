using loja_api.application.Mapper.Storage;
using MediatR;

namespace loja_api.application.Commands.Storage;

public class CreateStorageCommands : IRequest
{
    public StorageCreateDTO StorageCreateDTO { get; set; }
}
