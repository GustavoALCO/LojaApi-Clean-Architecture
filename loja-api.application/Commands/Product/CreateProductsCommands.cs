    using loja_api.application.Mapper.Product;
    using MediatR;

    namespace loja_api.application.Commands.Product;

    public class CreateProductsCommands : IRequest<bool>
    {
        public required ProductsCreateDTO productsCreateDTO;
    }
