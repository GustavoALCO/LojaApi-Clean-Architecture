using AutoMapper;
using loja_api.application.Mapper.Storage;
using loja_api.application.Queries.Storage;
using loja_api.domain.Interfaces.Storage;
using MediatR;

namespace loja_api.application.Queries.Handlers.Storage;

public class GetIdStorageAsyncHandler : IRequestHandler<GetIdStorageAsyncQuery, StorageDTO>
{
    private readonly IStorageRepositoryQueries _StorageRepositoryQueries;

    private readonly IMapper _mapper;

    public GetIdStorageAsyncHandler(IMapper mapper, IStorageRepositoryQueries storageRepositoryQueries)
    {
        _mapper = mapper;
        _StorageRepositoryQueries = storageRepositoryQueries;
    }

    public Task<StorageDTO> Handle(GetIdStorageAsyncQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
