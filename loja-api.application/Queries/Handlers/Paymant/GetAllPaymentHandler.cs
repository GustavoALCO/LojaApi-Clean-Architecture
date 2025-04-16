using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Paymant;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Queries.Handlers.Paymant;

public class GetAllPaymentHandler : IRequestHandler<GetAllPaymantQuery, IEnumerable<PaymantDTO>>
{
    private readonly IpaymantRepositotyQuery _query;

    private readonly IMapper _mapper;

    public GetAllPaymentHandler(IpaymantRepositotyQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PaymantDTO>> Handle(GetAllPaymantQuery request, CancellationToken cancellationToken)
    {
        var user =_mapper.Map<IEnumerable<PaymantDTO>>(await _query.BuscarTodasAsCompras(request.page));

        if (user.Count() < 1)
            throw new Exception("Não Existe Compras");

        return user;
    }
}
