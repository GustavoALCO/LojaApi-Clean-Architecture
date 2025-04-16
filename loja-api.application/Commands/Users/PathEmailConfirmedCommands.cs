using MediatR;

namespace loja_api.application.Commands.Users;

public class PathEmailConfirmedCommands : IRequest
{
    public Guid Id { get; set; }  
}
