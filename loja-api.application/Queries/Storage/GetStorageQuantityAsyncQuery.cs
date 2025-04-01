using MediatR;

namespace loja_api.application.Queries.Storage;

public class GetStorageQuantityAsyncQuery : IRequest<int>
{
    public Guid IdProducts { get; set; }
}
