using loja_api.application.Mapper.Cupom;
using MediatR;

namespace loja_api.application.Queries.Cupom;

public class GetAllCupomQuery : IRequest<IEnumerable<CupomDTO>>
{
}
