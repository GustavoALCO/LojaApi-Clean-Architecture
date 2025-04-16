using loja_api.application.Commands.Users;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Users;

public class PathEmailConfirmedHandlers : IRequestHandler<PathEmailConfirmedCommands>
{
    private readonly IUserRepositoryQueries _queries;

    private readonly IUserRepositoryCommands _commands;

    public PathEmailConfirmedHandlers(IUserRepositoryCommands commands, IUserRepositoryQueries queries)
    {
        _commands = commands;
        _queries = queries;
    }

    public async Task Handle(PathEmailConfirmedCommands request, CancellationToken cancellationToken)
    {
        var user = await _queries.GetUserIdAsync(request.Id);

        if (user == null)
            throw new Exception("Não foi possivel achar o Usuario");

        user.EmailConfirmed = true;

        await _commands.UpdateUser(user);
    }
}
