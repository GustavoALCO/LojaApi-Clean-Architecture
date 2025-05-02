using loja_api.application.Mapper.Employee;
using MediatR;

namespace loja_api.application.Commands.Employee;

public class CreateEmployeeCommands : IRequest
{
    public required string FullName { get; set; }

    public required string Login { get; set; }

    public required string Password { get; set; }

    public required string Position { get; set; }

    public int CreatebyId { get; set; }
}
