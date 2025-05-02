using AutoMapper;
using loja_api.application.Mapper.Storage;
using loja_api.application.Queries.Storage;
using loja_api.domain.Interfaces.Storage;
using MediatR;

namespace loja_api.application.Queries.Handlers.Storage;

public class GetAllStoragesHandler : IRequestHandler<GetAllStoragesAsyncQuery, IEnumerable<StorageDTO>>
{

    private readonly IStorageRepositoryQueries _StorageRepositoryQueries;

    private readonly IMapper _mapper;

    public GetAllStoragesHandler(IStorageRepositoryQueries storageRepositoryQueries, IMapper mapper)
    {
        _StorageRepositoryQueries = storageRepositoryQueries;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StorageDTO>> Handle(GetAllStoragesAsyncQuery request, CancellationToken cancellationToken)
    {
        var storage = await _StorageRepositoryQueries.GetStoragesAllAsync();

        if (storage == null)
            throw new Exception("Não foi possivel encontrar nenhum storage");

        return _mapper.Map<IEnumerable<StorageDTO>>(storage);
    }
}
