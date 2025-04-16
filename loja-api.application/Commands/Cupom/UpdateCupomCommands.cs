using loja_api.application.Mapper.Cupom;
using MediatR;

namespace loja_api.application.Commands.Cupom;

public class UpdateCupomCommands : IRequest
{
    public Guid Id { get; set; }

    public CupomUpdateDTO CupomUpdateDTO { get; set; }
}
