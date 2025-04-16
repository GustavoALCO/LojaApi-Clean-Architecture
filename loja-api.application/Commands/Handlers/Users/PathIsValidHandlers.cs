using loja_api.application.Commands.Users;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Users;

public class PathIsValidHandlers : IRequestHandler<PathIsValidCommands>
{
    private readonly IUserRepositoryCommands _commands;

    private readonly IUserRepositoryQueries _queries;

    public PathIsValidHandlers(IUserRepositoryQueries queries, IUserRepositoryCommands commands)
    {
        _queries = queries;
        _commands = commands;
    }

    public async Task Handle(PathIsValidCommands request, CancellationToken cancellationToken)
    {
        var User = await _queries.GetUserIdAsync(request.Id);

        if (User == null)
            throw new Exception("Usuario não Encontrado");

        if(User.IsValid == false)
        {
            User.IsValid = true;
            await _commands.UpdateUser(User);
            await Task.CompletedTask;
        }

        User.IsValid = false;
        await _commands.UpdateUser(User);
        await Task.CompletedTask;
            
    }
}
