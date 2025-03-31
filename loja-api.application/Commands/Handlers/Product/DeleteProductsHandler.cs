using loja_api.application.Commands.Product;
using loja_api.domain.Interfaces.products;
using MediatR;

namespace loja_api.application.Commands.Handlers.Product;

public class DeleteProductsHandler : IRequestHandler<DeleteProductsCommands, bool>
{
    private readonly IProductsQueryRepository _productsQueryRepository;

    private readonly IProductsRepositoryCommands _productsRepositoryCommands;

    public DeleteProductsHandler(IProductsRepositoryCommands productsRepositoryCommands, IProductsQueryRepository productsQueryRepository)
    {
        _productsRepositoryCommands = productsRepositoryCommands;
        _productsQueryRepository = productsQueryRepository;
    }

    public async Task<bool> Handle(DeleteProductsCommands request, CancellationToken cancellationToken)
    {
        //Busca no banco de dados o Id Selecionado
        var product = await _productsQueryRepository.GetProductsIDAsync(request.Id);

        if (product == null)
            //Se caso não encontrar chama uma execption que não foi encontrado nada
            throw new ArgumentNullException("Produto Não encontrado");

        //Chama a Interface para deletar produtos
        await _productsRepositoryCommands.DeleteProductsAsync(product);

        return true;
    }
}
