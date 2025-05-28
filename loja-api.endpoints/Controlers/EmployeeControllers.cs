using loja_api.application.Commands.Employee;
using loja_api.application.Mapper.Employee;
using loja_api.application.Queries.Employee;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;

public class EmployeeControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public EmployeeControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("BucarTodos")]
    public async Task<IActionResult> GetAllEmployee(GetAllEmployeeQuery getAllEmployeeQuery)
    {
            var employee = await _mediator.Send(getAllEmployeeQuery);

            return Ok(employee);
    }

    [Authorize]
    [HttpGet("BuscarPorID/{id}")]
    public async Task<IActionResult> GetEmployeeId(GetEmployeeIdQueries getEmployeeIdQueries)
    {
            var emoloyee = await _mediator.Send(getEmployeeIdQueries);

            return Ok(emoloyee);
    }

    [Authorize]
    [HttpPost("CriarFuncionario")]
    public async Task<IActionResult> CreateEmployee([FromBody]CreateEmployeeCommands createEmployee)
    {
            await _mediator.Send(createEmployee);

            return Ok();
    }

    [Authorize]
    [HttpPut("AlterarFuncionario/{id}")]
    public async Task<IActionResult> UpdateEmployee(EmployeeUpdateDTO employeeUpdateDTO, int id)
    {
        await _mediator.Send(new UpdateEmployeeCommands { Id = id, UpdateEmployee = employeeUpdateDTO });

        return Ok();
    }

    [Authorize]
    [HttpPatch("AlterarSenha/{id}")]
    public async Task<IActionResult> UpdatePassword(int id, string password)
    {
        await _mediator.Send(new UpdatePasswordEmployeeCommands { Id = id , NewPassword = password });  

        return Ok();
    }
}
