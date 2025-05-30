using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Paymant;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Queries.Handlers.Paymant;

public class GetAllPaymentHandler : IRequestHandler<GetAllPaymantQuery, IEnumerable<domain.Entities.Paymant>>
{
    private readonly IpaymantRepositotyQuery _query;

    private readonly IMapper _mapper;

    public GetAllPaymentHandler(IpaymantRepositotyQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<domain.Entities.Paymant>> Handle(GetAllPaymantQuery request, CancellationToken cancellationToken)
    {
        var user = await _query.BuscarTodasAsCompras(request.page);

        if (user.Count() < 1)
            throw new Exception("Não Existe Compras");

        return user;
    }
}
