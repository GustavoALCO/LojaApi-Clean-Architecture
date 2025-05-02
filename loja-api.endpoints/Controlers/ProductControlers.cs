using loja_api.application.Commands.Product;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace loja_api.endpoints.Controlers;


[Route("api/[controller]")]
public class ProductControlers : ControllerBase
{

    private readonly IMediator _mediator;

    public ProductControlers(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductsId([FromRoute] Guid Id)
    {
        try
        {
           var result = await _mediator.Send(new GetProductsIDQuery { Id = Id});

            if (result != null) 
                return NotFound(new { Message = $"não foi possivel encontrar o Produto, Verifique se o ID : {Id} está correto"});

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet("GetProductsName/{name}/{page}")]
    public async Task<IActionResult> GetAllProducts(string name, int page)
    {
        try
        {
            var results = await _mediator.Send(new GetAllProductsNameQuery { ProductsName = name, Page = page });

            if (results.Count() == 0)
                return NotFound(new {Message = $"Não foi possivel encontrar nenhum produto que contem o nome de : {name} verifique se esta correto" });

            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }

    }
    [HttpGet("GetProductsFilter")]
    public async Task<IActionResult> GetProductsFilter([FromBody]ProductsFilterDTO productsFilterDTO)
    {
        try
        {
            var results = await _mediator.Send(new GetProductsFilterQuery { FilterDTO = productsFilterDTO });

            if (results.Count() == 0)
                return NotFound(new { Message = $"Não foi possivel encontrar nenhum Produto com o filtro {productsFilterDTO}" });

            return Ok(results);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
        
    }
    [HttpPost("CreateProducts")]
    public async Task<IActionResult> CreateProductsFilter([FromBody]ProductsCreateDTO productsCreate)
    {
        try
        {
            var products = await _mediator.Send(new CreateProductsCommands { productsCreateDTO = productsCreate });

            return Ok("Produto criado com Sucesso");
        }
        catch (Exception ex)
        {
            return NotFound(ex.ToString());
        }
       
    }

    [HttpPut("UpdateProducts")]
    public async Task<IActionResult> UpdateProducts([FromBody]ProductsUpdateDTO updateDTO)
    {
        try
        {
            var response = await _mediator.Send(new UpdateProductsCommands { ProductsUpdateDTO = updateDTO});

            return Ok(response);    
        }
        catch (Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpPatch("UpdateImages")]
    public async Task<IActionResult> UpdateImagesAsync([FromQuery] Guid Id, [FromBody] List<string> Images)
    {
        try
        {
            var products = await _mediator.Send(new GetProductsIDQuery { Id = Id});

            if (products == null)
                throw new Exception("Erro Ao encontrar Produto");

            var response = await _mediator.Send(new UpdateImageProductsCommands { Id = Id , Images = Images});

            return Ok(response);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

    [HttpDelete("DeleteProducts")]
    public async Task<IActionResult> DeleteProducts([FromQuery] Guid Id)
    {
        try
        {
            var response = await _mediator.Send(new DeleteProductsCommands { Id = Id });

            return Ok(response);
        }
        catch(Exception ex)
        {
            return BadRequest(ex.ToString());
        }
    }

}
