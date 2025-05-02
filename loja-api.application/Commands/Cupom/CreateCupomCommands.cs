using loja_api.application.Mapper.Cupom;
using MediatR;

namespace loja_api.application.Commands.Cupom;

public class CreateCupomCommands : IRequest
{
    public required string Name { get; set; }

    public required int Discount { get; set; }

    public required int Quantity { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int CreatebyId { get; set; }

}
