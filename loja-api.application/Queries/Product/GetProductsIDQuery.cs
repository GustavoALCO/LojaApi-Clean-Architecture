using loja_api.application.Mapper.Product;
using MediatR;

namespace loja_api.application.Queries.Product;

public class GetProductsIDQuery : IRequest<ProductsDTO>
{
    public Guid Id { get; set; }

}
