using MediatR;

namespace loja_api.application.Commands.Employee;

public class GetLoginEmployeeCommands : IRequest<string>
{
    public string Login;

    public string Password;

}
