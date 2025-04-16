using loja_api.application.Mapper.Employee;
using MediatR;

namespace loja_api.application.Commands.Employee;

public class UpdateEmployeeCommands : IRequest
{
    public int Id { get; set; }
    public EmployeeUpdateDTO UpdateEmployee { get; set; }
}
