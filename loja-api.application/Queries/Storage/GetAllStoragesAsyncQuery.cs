using loja_api.application.Mapper.Storage;
using MediatR;

namespace loja_api.application.Queries.Storage;

public class GetAllStoragesAsyncQuery : IRequest<IEnumerable<StorageDTO>>
{
    public Guid IdProducts { get; set; }
}
