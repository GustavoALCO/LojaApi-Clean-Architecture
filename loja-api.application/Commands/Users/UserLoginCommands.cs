using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Commands.Users;

public class UserLoginCommands : IRequest<string>
{
    public UserLoginDTO User { get; set; }
}
