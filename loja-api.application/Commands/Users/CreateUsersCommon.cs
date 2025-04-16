using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Commands.Users;

public class CreateUsersCommon : IRequest
{
    public UserCreateDTO User { get; set; }
}
