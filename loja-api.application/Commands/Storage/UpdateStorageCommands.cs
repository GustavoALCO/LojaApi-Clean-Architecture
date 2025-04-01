using loja_api.application.Mapper.Storage;
using MediatR;

namespace loja_api.application.Commands.Storage;

public class UpdateStorageCommands : IRequest
{
    public StorageUpdateDTO StorageUpdateDTO { get; set; }

}
