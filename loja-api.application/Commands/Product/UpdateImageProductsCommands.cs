using MediatR;

namespace loja_api.application.Commands.Product;

public class UpdateImageProductsCommands : IRequest<string>
{

    public Guid Id { get; set; }

    public List<string> Images { get; set; }
}