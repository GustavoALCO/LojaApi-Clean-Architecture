using AutoMapper;
using loja_api.application.Commands.Employee;
using loja_api.application.Interfaces;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Commands.Handlers.Employee;

public class CreateEmployeeHandlers : IRequestHandler<CreateEmployeeCommands>
{
    private readonly IEmployeeRepositoryCommands _commands;

    private readonly IEmployeeRepositoryQuery _query;

    private readonly IMapper _mapper;

    private readonly IHashService _hashService;

    public CreateEmployeeHandlers(IEmployeeRepositoryQuery query, IEmployeeRepositoryCommands commands, IMapper mapper, IHashService hashService)
    {
        _query = query;
        _commands = commands;
        _mapper = mapper;
        _hashService = hashService;
    }

    public async Task Handle(CreateEmployeeCommands request, CancellationToken cancellationToken)
    {
        var employeeVerify = await _query.GetEmployeeLoginAsync(request.Login);

        if (employeeVerify != null)
            throw new Exception("Usuario Com Login Existente");

         var employee = new domain.Entities.Employee
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

        };
        employee.Password = _hashService.CreateHash(employee, request.Password);

        await _commands.CreateEmployeeAsync(employee);
    }
}
