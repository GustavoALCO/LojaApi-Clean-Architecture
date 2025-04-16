using loja_api.application.Commands.Users;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Users;

public class DeleteUserHandlers : IRequestHandler<DeleteUserCommands>
{
    private readonly IUserRepositoryCommands _commands;

    private readonly IUserRepositoryQueries _queries;

    public DeleteUserHandlers(IUserRepositoryQueries queries, IUserRepositoryCommands commands)
    {
        _queries = queries;
        _commands = commands;
    }

    public async Task Handle(DeleteUserCommands request, CancellationToken cancellationToken)
    {
        try
        {
            var User = await _queries.GetUserIdAsync(request.Id);

            if (User == null)
                throw new Exception("Não foi possivel encontrar nenhum Usuario");

            await _commands.DeleteUser(User);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.ToString());
        }
         
    }
}
