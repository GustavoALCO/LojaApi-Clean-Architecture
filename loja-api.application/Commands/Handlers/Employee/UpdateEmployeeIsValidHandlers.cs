using loja_api.application.Commands.Employee;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Commands.Handlers.Employee;

public class UpdateEmployeeIsValidHandlers : IRequestHandler<UpdateIsValidEmployeeCommands>
{
    private readonly IEmployeeRepositoryCommands _commands;

    private readonly IEmployeeRepositoryQuery _query;

    public async Task Handle(UpdateIsValidEmployeeCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _query.GetEmployeeIDAsync(request.Id);

            if (employee == null)
                throw new Exception("Funcionario Não Encontrado");

            employee.IsActive = request.IsValid;

            await _commands.UpdateEmployeeAsync(employee);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
