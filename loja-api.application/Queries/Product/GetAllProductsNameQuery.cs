using loja_api.application.Mapper.Product;
using MediatR;

namespace loja_api.application.Queries.Product;

public class GetAllProductsNameQuery : IRequest<IEnumerable<ProductsDTO>>
{
    public string ProductsName { get; set; }

    public int Page { get; set; }
}
