using MediatR;

namespace loja_api.application.Commands.Employee;

public class UpdatePasswordEmployeeCommands : IRequest
{
    public required int Id { get; set; } 
    public required string NewPassword { get; set; }
}
