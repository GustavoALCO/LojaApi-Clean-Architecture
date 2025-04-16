using loja_api.application.Mapper.Employee;
using MediatR;

namespace loja_api.application.Commands.Employee;

public class CreateEmployeeCommands : IRequest
{
    public EmployeeCreateDTO EmployeeCreateDTO { get; set; }
}
