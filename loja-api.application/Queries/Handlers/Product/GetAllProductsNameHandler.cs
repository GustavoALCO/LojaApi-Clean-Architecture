using AutoMapper;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Product;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Queries.Handlers.Product;

public class GetAllProductsNameHandler : IRequestHandler<GetAllProductsNameQuery, IEnumerable<ProductsDTO>>
{
    private readonly IProductsQueryRepository _productsQueryRepository;

    private readonly IMapper _mapper;

    public GetAllProductsNameHandler(IMapper mapper, IProductsQueryRepository productsQueryRepository)
    {
        _mapper = mapper;
        _productsQueryRepository = productsQueryRepository;
    }

    public async Task<IEnumerable<ProductsDTO>> Handle(GetAllProductsNameQuery request, CancellationToken cancellationToken)
    {

        var products = await _productsQueryRepository.GetAllProductsAsync(request.ProductsName, request.Page);

        if (products == null)
            throw new ArgumentNullException(nameof(products));

        return _mapper.Map<IEnumerable<ProductsDTO>>(products);
    }
}
