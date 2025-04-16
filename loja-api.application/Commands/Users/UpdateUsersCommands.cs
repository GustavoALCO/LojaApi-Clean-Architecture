using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Commands.Users;

public class UpdateUsersCommands : IRequest
{
    public UserUpdateDTO User { get; set; }
}
