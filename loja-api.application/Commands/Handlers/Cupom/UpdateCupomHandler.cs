using AutoMapper;
using loja_api.application.Commands.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Commands.Handlers.Cupom;

public class UpdateCupomHandler : IRequestHandler<UpdateCupomCommands>
{
    private readonly ICupomRepositoryCommands _commands;

    private readonly ICupomRepositoryQuery _query;

    private readonly IMapper _mapper;

    public UpdateCupomHandler(IMapper mapper, ICupomRepositoryQuery query, ICupomRepositoryCommands commands)
    {
        _mapper = mapper;
        _query = query;
        _commands = commands;
    }

    public async Task Handle(UpdateCupomCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var cupom = await _query.GetCupom(request.Id);

            if (cupom == null)
                throw new Exception("Erro ao Buscar Cupom");

            _mapper.Map(request.CupomUpdateDTO, cupom);

            await _commands.UpdateCupomAsync(cupom);
        }
        catch(Exception ex)
        {
            throw new Exception(ex.ToString());
        }
    }
}
