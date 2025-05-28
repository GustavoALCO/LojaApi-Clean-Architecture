using loja_api.application.Commands.Paymant;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Queries.Paymant;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;

public class PaymantController : ControllerBase
{

    private readonly IMediator _mediator;

    public PaymantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [Authorize]
    [HttpGet("GetAllPaymants")]
    public async Task<IActionResult> GetAllPaymant([FromQuery]
                                                    int page)
    {
        try
        {
            var results = await _mediator.Send(new GetAllPaymantQuery { page = page});

            return Ok(results);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [Authorize]
    [HttpGet("GetAllPaymantsUser/{id}")]
    public async Task<IActionResult> GetAllPaymantsUser(Guid id,
                                                        [FromQuery]
                                                        int page)
    {
        try
        {
            var results = await _mediator.Send(new GetAllPaymantsUserQuery {Id = id, page = page });

            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [Authorize]
    [HttpGet("GetPaymants/{id}")]
    public async Task<IActionResult> GetIdPaymants(string id)
    {
        try
        {
            var results = await _mediator.Send(new GetIdPaymantQuery { Id = id});

            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPost("WebHook")]
    public async Task<IActionResult> RecibeWebHook([FromBody]
                                                    dynamic data)
    {
        try
        {
            await _mediator.Send(new UpdatePaymantCommands{ data = data });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [Authorize]
    [HttpPost("CreatePaymant")]
    public async Task<IActionResult> CreatePayment([FromBody]
                                                    PaymantDTO paymantDTO)
    {
        try
        {
            await _mediator.Send(new CreatePaymantCommands { PaymantDTO = paymantDTO });

            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

}
