using MediatR;

namespace loja_api.application.Commands.Employee;

public class PostLoginEmployeeCommands : IRequest<string>
{
    public string Login { get; set; }

    public string Password { get; set; }

}
