using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.Paymant.ProductsPaymant;
using MediatR;

namespace loja_api.application.Commands.Paymant;

public class CreatePaymantCommands : IRequest<string>
{
    public required Guid UserId { get; set; }

    public Guid CupomId { get; set; }

    public required List<ProductsPaymant> ProductsMarket { get; set; }
}
