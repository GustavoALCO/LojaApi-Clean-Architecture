using MediatR;

namespace loja_api.application.Commands.Cupom;

public class CreateCupomCommands : IRequest
{
    public CreateCupomCommands CreateCupom { get; set; }

}
