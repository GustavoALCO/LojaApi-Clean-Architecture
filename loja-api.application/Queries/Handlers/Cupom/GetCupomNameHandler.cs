using loja_api.application.Queries.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Queries.Handlers.Cupom;

public class GetCupomNameHandler : IRequestHandler<GetCupomNameQuery, bool>
{
    private readonly ICupomRepositoryQuery _query;

    public GetCupomNameHandler(ICupomRepositoryQuery query)
    {
        _query = query;
    }

    public async Task<bool> Handle(GetCupomNameQuery request, CancellationToken cancellationToken)
    {
        var response = await _query.GetCupomNameAsync(request.Name);

        if (response == null)
            throw new Exception("Cupom Não Encontrado");

        return true;
    }
}
