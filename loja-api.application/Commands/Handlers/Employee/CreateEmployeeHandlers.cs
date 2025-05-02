using AutoMapper;
using loja_api.application.Commands.Employee;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Commands.Handlers.Employee;

public class CreateEmployeeHandlers : IRequestHandler<CreateEmployeeCommands>
{
    private readonly IEmployeeRepositoryCommands _commands;

    private readonly IEmployeeRepositoryQuery _query;

    private readonly IMapper _mapper;

    public CreateEmployeeHandlers(IEmployeeRepositoryQuery query, IEmployeeRepositoryCommands commands, IMapper mapper)
    {
        _query = query;
        _commands = commands;
        _mapper = mapper;
    }

    public async Task Handle(CreateEmployeeCommands request, CancellationToken cancellationToken)
    {
        var employee = await _query.GetEmployeeLoginAsync(request.Login);

        if (employee != null)
            throw new Exception("Usuario Com Login Existente");

        await _commands.CreateEmployeeAsync(new domain.Entities.Employee
        {
            FullName = request.FullName,
            Login = request.Login,
            Password = request.Password,    
            Position = request.Position,
            IsActive = true,
            Auditable = new domain.Entities.auxiliar.Auditable {
                                                                 CreatebyId = request.CreatebyId,
                                                                 CreateDate = DateTime.Now
                                                                }

        });

    }
}
