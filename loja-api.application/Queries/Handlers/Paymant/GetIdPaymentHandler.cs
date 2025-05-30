using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Queries.Paymant;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Queries.Handlers.Paymant;

public class GetIdPaymentHandler : IRequestHandler<GetIdPaymantQuery, PaymantDTO>
{

    private readonly IpaymantRepositotyQuery _query;

    private readonly IMapper _mapper;

    public GetIdPaymentHandler(IpaymantRepositotyQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<PaymantDTO> Handle(GetIdPaymantQuery request, CancellationToken cancellationToken)
    {
        var paymant = _mapper.Map<PaymantDTO>(await _query.BuscarCompra(Guid.Parse(request.Id)));

        return paymant;
    }
}
