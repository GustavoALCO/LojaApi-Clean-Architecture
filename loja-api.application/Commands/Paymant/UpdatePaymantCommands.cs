using MediatR;

namespace loja_api.application.Commands.Paymant;

public class UpdatePaymantCommands : IRequest
{

    public dynamic data { get; set; }

}
