using MediatR;

namespace loja_api.application.Commands.Users;

public class PathIsValidCommands : IRequest
{
    public Guid Id { get; set; }
}
