using loja_api.application.Commands.Storage;
using loja_api.application.Mapper.Storage;
using loja_api.application.Queries.Storage;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace loja_api.endpoints.Controlers;

[Route("api/[controller]")]
public class StorageController : ControllerBase
{
    private readonly IMediator _mediator;

    public StorageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetValueStorage")]
    public async Task<IActionResult> GetValueStorage([FromQuery]Guid IdProducts)
    {
        try
        {
            var value = await _mediator.Send(new GetStorageQuantityAsyncQuery { IdProducts = IdProducts });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }

    [HttpGet("GetStorageID")]
    public async Task<IActionResult> GetStorageId([FromQuery]Guid IdStorage)
    {
        try
        {
            var value = await _mediator.Send(new GetIdStorageAsyncQuery { IdStorage = IdStorage });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }

    [HttpGet("GetAllStorage")]
    public async Task<IActionResult> GetAllStorages()
    {
        try
        {
            var value = await _mediator.Send(new GetAllStoragesAsyncQuery { });

            return Ok(value);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }

    [HttpPost("PostStorages")]
    public async Task<IActionResult> PostStorageAsync([FromBody] StorageCreateDTO storageCreateDTO)
    {
        try
        {
            await _mediator.Send(new CreateStorageCommands { StorageCreateDTO = storageCreateDTO });

            return Ok();

        }catch (Exception ex)
        {
            return BadRequest(ex.Message.ToList());
        }
    }

    [HttpDelete("DeleteStorage")]
    public async Task<IActionResult> DeleteStorage([FromQuery] Guid idStorage)
    {
        try
        {
            await _mediator.Send(new DeleteStorageCommands { StorageId = idStorage });

            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }

    [HttpPut("AlterarStorage")]
    public async Task<IActionResult> AlterarStorage([FromBody] StorageUpdateDTO storageUpdateDTO)
    {
        try
        {
            await _mediator.Send(new UpdateStorageCommands { StorageUpdateDTO = storageUpdateDTO });

            return Ok();
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message.ToString());
        }
    }
}
