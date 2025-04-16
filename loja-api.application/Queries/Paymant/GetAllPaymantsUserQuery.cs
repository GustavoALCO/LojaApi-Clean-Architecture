using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.Product;
using MediatR;

namespace loja_api.application.Queries.Paymant;

public class GetAllPaymantsUserQuery : IRequest<IEnumerable<PaymantDTO>>
{
    public Guid Id { get; set; }

    public int page { get; set; }
}
