using loja_api.application.Commands.Employee;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces.Employee;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace loja_api.application.Commands.Handlers.Employee;

public class UpdatePasswordEmployeeHandler : IRequestHandler<UpdatePasswordEmployeeCommands>
{

    private readonly IEmployeeRepositoryQuery _query;

    private readonly IEmployeeRepositoryCommands _command;

    private readonly IHashService _PasswordHasher;

    public UpdatePasswordEmployeeHandler(IHashService passwordHasher, IEmployeeRepositoryCommands command, IEmployeeRepositoryQuery query)
    {
        _PasswordHasher = passwordHasher;
        _command = command;
        _query = query;
    }

    public async Task Handle(UpdatePasswordEmployeeCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _query.GetEmployeeIDAsync(request.Id);

            if (employee == null)
                throw new Exception("Funcionario Não Encontrado");

            employee.Password = _PasswordHasher.CreateHash(employee, request.NewPassword);

            await _command.UpdateEmployeeAsync(employee);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.ToString());
        }    
    }
}
