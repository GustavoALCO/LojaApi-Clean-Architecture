using MediatR;

namespace loja_api.application.Commands.Product;

public class DeleteProductsCommands : IRequest<bool>
{
    public required Guid Id { get; set; }
}
