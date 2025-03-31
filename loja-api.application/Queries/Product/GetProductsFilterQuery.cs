using loja_api.application.Mapper.Product;
using MediatR;

namespace loja_api.application.Queries.Product;

public class GetProductsFilterQuery : IRequest<IEnumerable<ProductsDTO>>
{
    public ProductsFilterDTO FilterDTO { get; set; }
}
