using AutoMapper;
using loja_api.application.Commands.Employee;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Commands.Handlers.Employee;

public class UpdateEmployeeHandlers : IRequestHandler<UpdateEmployeeCommands>
{
    private readonly IEmployeeRepositoryQuery _query;

    private readonly IEmployeeRepositoryCommands _command;

    private readonly IMapper _mapper;

    public UpdateEmployeeHandlers(IEmployeeRepositoryCommands command, IEmployeeRepositoryQuery query, IMapper mapper)
    {
        _command = command;
        _query = query;
        _mapper = mapper;
    }

    public async Task Handle(UpdateEmployeeCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _query.GetEmployeeIDAsync(request.Id);

            if (employee == null)
                throw new Exception("Funcionario Não Encontrado");

            _mapper.Map(request.UpdateEmployee, employee);

            await _command.UpdateEmployeeAsync(employee);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }   
    }
}
