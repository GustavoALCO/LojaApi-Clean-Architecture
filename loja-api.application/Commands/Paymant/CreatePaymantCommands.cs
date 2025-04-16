using loja_api.application.Mapper.Paymant;
using MediatR;

namespace loja_api.application.Commands.Paymant;

public class CreatePaymantCommands : IRequest<string>
{
    public PaymantDTO PaymantDTO { get; set; }
}
