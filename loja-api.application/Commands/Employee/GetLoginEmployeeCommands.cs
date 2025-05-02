using MediatR;

namespace loja_api.application.Commands.Employee;

public class GetLoginEmployeeCommands : IRequest<string>
{
    public required string Login;

    public required string Password;

}
