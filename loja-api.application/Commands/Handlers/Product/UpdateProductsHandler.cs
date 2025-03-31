using AutoMapper;
using loja_api.application.Commands.Product;
using loja_api.application.Mapper.Product;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Commands.Handlers.Product;

public class UpdateProductsHandler : IRequestHandler<UpdateProductsCommands, string>
{
    private readonly IProductsQueryRepository _productsQueryRepository;

    private readonly IProductsRepositoryCommands _productsRepositoryCommands;

    private readonly IMapper _mapper;

    public UpdateProductsHandler(IMapper mapper, IProductsQueryRepository productsQueryRepository, IProductsRepositoryCommands productsRepositoryCommands = null)
    {
        _mapper = mapper;
        _productsQueryRepository = productsQueryRepository;
        _productsRepositoryCommands = productsRepositoryCommands;
    }

    public async Task<string> Handle(UpdateProductsCommands request, CancellationToken cancellationToken)
    {
        //Busca no banco de dados o produto com o Id Selecionado
         var products = await _productsQueryRepository.GetProductsIDAsync(request.ProductsUpdateDTO.IdProducts);
        //Se o produto não for encontrado é passado uma exception
        if (products == null) 
            throw new ArgumentNullException("Produto não encontrado");

        //Faz a Alteração passando o valor de productUpdate para Products
        _mapper.Map(request.ProductsUpdateDTO, products);

        //Salva no banco de dados
        await _productsRepositoryCommands.UpdateProductsAsync(products);

        return "Produto Alterado Com Sucesso";
    }
}
