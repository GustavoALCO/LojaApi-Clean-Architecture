using loja_api.application.Mapper.Paymant;
using MediatR;

namespace loja_api.application.Queries.Paymant;

public class GetIdPaymantQuery : IRequest<PaymantDTO>
{
    public string Id { get; set; }
}
