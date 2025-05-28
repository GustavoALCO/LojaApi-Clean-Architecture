using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Commands.Users;

public class UserLoginCommands : IRequest<string>
{
    public required string Email { get; set; }

    public required string Password { get; set; }
}
