using loja_api.domain.Interfaces.Storage;
using MediatR;

namespace loja_api.application.Queries.Storage.Handler;

public class GetStorageQuantityHandlers : IRequestHandler<GetStorageQuantityAsyncQuery, int>
{
    private readonly IStorageRepositoryQueries? _StorageRepositoryQueries;


    public async Task<int> Handle(GetStorageQuantityAsyncQuery request, CancellationToken cancellationToken)
    {
        int value = await _StorageRepositoryQueries.GetStorageQuantityAsync(request.IdProducts);

        if (value == 0)
            throw new Exception("Não Há produtos do estoque, ou não foi possivel encontrar");

        return value;
    }
}
