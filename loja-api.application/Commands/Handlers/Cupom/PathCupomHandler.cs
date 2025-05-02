using loja_api.application.Commands.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Commands.Handlers.Cupom;

public class PathCupomHandler : IRequestHandler<PathCupomCommands>
{
    private readonly ICupomRepositoryCommands _commands;

    private readonly ICupomRepositoryQuery _query;

    public PathCupomHandler(ICupomRepositoryCommands commands, ICupomRepositoryQuery query)
    {
        _commands = commands;
        _query = query;
    }


    public async Task Handle(PathCupomCommands request, CancellationToken cancellationToken)
    {
        var cupom = await _query.GetCupom(request.Id);

        if (cupom == null)
            throw new Exception("Não existe nenhum Cupom com este ID");

        cupom.IsValid = !cupom.IsValid;

        await _commands.UpdateCupomAsync(cupom);
    }
}
