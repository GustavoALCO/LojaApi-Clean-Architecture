using AutoMapper;
using loja_api.application.Commands.Cupom;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Commands.Handlers.Cupom;

public class CreateCupomHandler : IRequestHandler<CreateCupomCommands>
{
    private readonly ICupomRepositoryCommands _commands;

    public CreateCupomHandler(ICupomRepositoryCommands commands)
    {
        _commands = commands;
    }

    public async Task Handle(CreateCupomCommands request, CancellationToken cancellationToken)
    {
        if (request.Discount < 1 || request.Quantity < 1)
            throw new Exception("Verifique se Discount ou Quantity tem valor");

        await _commands.CreateCupomAsync(new domain.Entities.Cupom { CupomId = Guid.NewGuid(),
                                                                     Name = request.Name,
                                                                     Discount = request.Discount,
                                                                     Quantity = request.Quantity,
                                                                     IsValid = true,    
                                                                     Auditable = new Auditable { CreatebyId = request.CreatebyId,
                                                                                                 CreateDate =  DateTime.UtcNow}
        
                                                                    });
    }
}
