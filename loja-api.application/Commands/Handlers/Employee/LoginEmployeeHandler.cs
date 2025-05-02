using loja_api.application.Commands.Employee;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Commands.Handlers.Employee;

public class LoginEmployeeHandler : IRequestHandler<GetLoginEmployeeCommands, string>
{
    private readonly IEmployeeRepositoryQuery _query;

    private readonly IHashService _hashService;

    private readonly IJwtService _jwtService;

    public LoginEmployeeHandler(IHashService hashService, IEmployeeRepositoryQuery query, IJwtService jwtService)
    {
        _hashService = hashService;
        _query = query;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(GetLoginEmployeeCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _query.GetEmployeeLoginAsync(request.Login);

            if (employee == null)
                throw new Exception("Funcionario Não Encontrado");

            bool response = _hashService.ValidatePassword(employee, employee.Password, request.Password);

            if (response == false)
                throw new Exception("Senha Incorreta");

            return _jwtService.GerarTokenLogin(request.Login, employee.Position);

        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
