using loja_api.application.Commands.Cupom;
using loja_api.application.Mapper.Cupom;
using loja_api.application.Queries.Cupom;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;

public class CupomControllers : ControllerBase
{

    private readonly IMediator _mediator;

    public CupomControllers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("BuscarCuponsValidos")]
    public async Task<IActionResult> GetAllCupons([FromQuery] 
                                                    int page)
    {
        return Ok(await _mediator.Send(new GetAllCupomQuery { page = page }));
    }

    [HttpGet("BuscarCupons/{id}")]
    public async Task<IActionResult> GetAllCupons(Guid id)
    {
        return Ok(await _mediator.Send(new GetCupomIdQuery { Id = id }));
    }

    [HttpGet("BucarCuponsFilter")]
    public async Task<IActionResult> GetFilterCupom(GetCupomFiltersQuery query)
    {
        return Ok(await _mediator.Send(query));
    }

    [HttpPost("CriarCupons")]
    public async Task<IActionResult> CreateCupom([FromBody]
                                                    CreateCupomCommands createCupomCommands)
    {
        await _mediator.Send(createCupomCommands);

        return Ok();
    }

    [HttpPut("UpdateCupom")]
    public async Task<IActionResult> UpdateCupom([FromQuery]
                                                Guid Id,                               
                                                [FromBody]
                                                 CupomUpdateDTO cupom)
    {
        return Ok(_mediator.Send(new UpdateCupomCommands { Id = Id, CupomUpdateDTO = cupom }));
    }

    [HttpPatch("AlterarIsvalid")]
    public async Task<IActionResult> PathCupom(PathCupomCommands pathCupom)
    {
        await _mediator.Send(pathCupom);

        return Ok();
    }
}
