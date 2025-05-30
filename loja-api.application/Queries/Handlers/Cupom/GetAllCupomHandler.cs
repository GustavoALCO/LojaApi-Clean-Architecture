using AutoMapper;
using loja_api.application.Mapper.Cupom;
using loja_api.application.Queries.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Queries.Handlers.Cupom;

public class GetAllCupomHandler : IRequestHandler<GetAllCupomQuery, IEnumerable<CupomDTO>>
{
    private readonly ICupomRepositoryQuery _query;

    private readonly IMapper _mapper;

    public GetAllCupomHandler(ICupomRepositoryQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CupomDTO>> Handle(GetAllCupomQuery request, CancellationToken cancellationToken)
    {
        int page = request.page;

        if (page < 1)
            page = 1;

        return _mapper.Map<IEnumerable<CupomDTO>>(await _query.GetAllCuponsValid(page * 10));
    }
}
