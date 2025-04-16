using loja_api.application.Commands.Users;
using loja_api.application.Mapper.User;
using loja_api.application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;

public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("BuscarUsuarios")]
    public async Task<IActionResult> GetAllUsers([FromQuery]
                                                 string? name,
                                                 [FromQuery]
                                                 int page)
    {
        try
        {
            var value = await _mediator.Send(new GetAllUsers { UserName = name, Page = page });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpGet("BuscarUsuario{Id}")]
    public async Task<IActionResult> GetUserId(Guid Id)
    {
        try
        {
            var value = await _mediator.Send(new GetUserID { UserID = Id });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpGet("BuscarUsuarioEmail")]
    public async Task<IActionResult> GetUserEmail(string Email)
    {
        try
        {
            var value = await _mediator.Send(new GetUserEmail { Email = Email });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpGet("FiltroUser")]
    public async Task<IActionResult> FilterUser([FromBody]
                                                UserFilterDTO user)
    {
        try
        {
            var value = await _mediator.Send(new GetUserFilter
            {
                Filter = user
            });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost("CreateUser")]
    public async Task<IActionResult> PostUser([FromBody] UserCreateDTO userCreate)
    {
        try
        {
            await _mediator.Send(new CreateUsersCommon { User = userCreate });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpDelete("DeleteUser{Id}")]
    public async Task<IActionResult> DeleteUser(Guid Id)
    {
        try
        {
            await _mediator.Send(new DeleteUserCommands { Id = Id });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPut("AlterarUser")]
    public async Task<IActionResult> PutUser([FromBody]
                                             UserUpdateDTO updateUsers)
    {
        try
        {
            await _mediator.Send(new UpdateUsersCommands { User = updateUsers });

            return Ok();
        } catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPatch("AtualizarIsValis{Id}")]
    public async Task<IActionResult> PathIsValid(Guid Id)
    {
        try
        {
            await _mediator.Send(new PathIsValidCommands { Id = Id });

            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPatch("ConfirmarEmail{Id}")]
    public async Task<IActionResult> PathEmail(Guid Id)
    {
        try
        {
            await _mediator.Send(new PathEmailConfirmedCommands { Id = Id });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }
}
