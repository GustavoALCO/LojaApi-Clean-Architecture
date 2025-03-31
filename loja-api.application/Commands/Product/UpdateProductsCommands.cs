using loja_api.application.Mapper.Product;
using MediatR;

namespace loja_api.application.Commands.Product;

public class UpdateProductsCommands : IRequest<string>
{
    public ProductsUpdateDTO ProductsUpdateDTO { get; set; }

}
