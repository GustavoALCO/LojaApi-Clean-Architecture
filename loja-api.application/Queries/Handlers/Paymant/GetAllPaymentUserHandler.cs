using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Queries.Paymant;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Queries.Handlers.Paymant;

public class GetAllPaymentUserHandler : IRequestHandler<GetAllPaymantsUserQuery, IEnumerable<PaymantDTO>>
{
    private readonly IpaymantRepositotyQuery _query;

    private readonly IMapper _mapper;

    public GetAllPaymentUserHandler(IpaymantRepositotyQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymantDTO>> Handle(GetAllPaymantsUserQuery request, CancellationToken cancellationToken)
    {
        var paymant = _mapper.Map<IEnumerable<PaymantDTO>>(await _query.BuscarTodasAsComprasUser(request.Id, request.page));

        return paymant;
    }
}
