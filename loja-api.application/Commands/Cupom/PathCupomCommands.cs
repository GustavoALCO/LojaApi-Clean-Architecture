using MediatR;

namespace loja_api.application.Commands.Cupom;

public class PathCupomCommands : IRequest
{
    public Guid Id { get; set; }
}
