using AutoMapper;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Product;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Queries.Handlers.Product;

public class GetProductsIDHandler : IRequestHandler<GetProductsIDQuery, ProductsDTO>
{
    private readonly IProductsQueryRepository _productsQueryRepository;

    private readonly IMapper _mapper;

    public GetProductsIDHandler(IProductsQueryRepository productsQueryRepository, IMapper mapper)
    {
        _productsQueryRepository = productsQueryRepository;
        _mapper = mapper;
    }

    public async Task<ProductsDTO> Handle(GetProductsIDQuery getProducts, CancellationToken cancellationToken)
    {
        //Busca a consulta no banco de dados dentro da interface    
        var product = await _productsQueryRepository.GetProductsIDAsync(getProducts.Id);

        //Faz uma verificação se o produto for nulo retorna uma exception informando o erro
        if (product == null)
            throw new KeyNotFoundException($"Não foi encontrado produto com o id {getProducts.Id}");

        //Mapeia o Produto para ProductDTO para ocultar algumas informaçoes 
        return _mapper.Map<ProductsDTO>(product);
    }

}
