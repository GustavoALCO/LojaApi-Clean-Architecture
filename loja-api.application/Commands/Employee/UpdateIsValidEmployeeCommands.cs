using MediatR;

namespace loja_api.application.Commands.Employee;

public class UpdateIsValidEmployeeCommands : IRequest
{
    public int Id { get; set; } 

    public bool IsValid { get; set; }
}
