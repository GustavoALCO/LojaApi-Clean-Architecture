using loja_api.application.Mapper.Paymant;
using MediatR;

namespace loja_api.application.Queries.Paymant;

public class GetAllPaymantQuery : IRequest<IEnumerable<domain.Entities.Paymant>>
{
    public int page { get; set; }
}
