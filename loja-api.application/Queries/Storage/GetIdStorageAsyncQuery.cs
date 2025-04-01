using loja_api.application.Mapper.Storage;
using MediatR;

namespace loja_api.application.Queries.Storage;

public class GetIdStorageAsyncQuery : IRequest<StorageDTO>
{
    public Guid IdStorage {  get; set; }
}
