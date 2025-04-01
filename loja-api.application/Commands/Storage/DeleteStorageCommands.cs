using MediatR;

namespace loja_api.application.Commands.Storage;

public class DeleteStorageCommands : IRequest
{
    public Guid StorageId { get; set; }
}
