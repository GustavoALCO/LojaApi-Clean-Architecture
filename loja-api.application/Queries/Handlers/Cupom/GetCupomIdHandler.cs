using AutoMapper;
using loja_api.application.Mapper.Cupom;
using loja_api.application.Queries.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Queries.Handlers.Cupom;

public class GetCupomIdHandler : IRequestHandler<GetCupomIdQuery, CupomDTO>
{
    private readonly ICupomRepositoryQuery _query;

    private readonly IMapper _mapper;

    public GetCupomIdHandler(ICupomRepositoryQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<CupomDTO> Handle(GetCupomIdQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<CupomDTO>(await _query.GetCupom(request.Id));
    }
}
