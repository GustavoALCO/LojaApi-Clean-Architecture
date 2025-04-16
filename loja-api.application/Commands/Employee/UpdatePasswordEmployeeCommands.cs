using MediatR;

namespace loja_api.application.Commands.Employee;

public class UpdatePasswordEmployeeCommands : IRequest
{
    public int Id { get; set; } 
    public string NewPassword { get; set; }
}
