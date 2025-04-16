using AutoMapper;
using loja_api.application.Commands.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Commands.Handlers.Cupom;

public class CreateCupomHandler : IRequestHandler<CreateCupomCommands>
{
    private readonly ICupomRepositoryCommands _commands;

    private readonly IMapper _mapper;

    public CreateCupomHandler(ICupomRepositoryCommands commands)
    {
        _commands = commands;
    }

    public async Task Handle(CreateCupomCommands request, CancellationToken cancellationToken)
    {
        try
        {
            await _commands.CreateCupomAsync(_mapper.Map<domain.Entities.Cupom>(request.CreateCupom));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }     
    }
}
