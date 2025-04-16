using AutoMapper;
using loja_api.application.Commands.Users;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Users;

public class UpdateUserHandlers : IRequestHandler<UpdateUsersCommands>
{
    private readonly IUserRepositoryCommands _commands;

    private readonly IUserRepositoryQueries _queries;

    private readonly IMapper _mapper;

    public UpdateUserHandlers(IMapper mapper, IUserRepositoryQueries queries, IUserRepositoryCommands commands)
    {
        _mapper = mapper;
        _queries = queries;
        _commands = commands;
    }

    public async Task Handle(UpdateUsersCommands request, CancellationToken cancellationToken)
    {
        var user = await _queries.GetUserIdAsync(request.User.IdUser);

        if (user == null)
            throw new Exception("Não encontrado o User");

        await _commands.UpdateUser(_mapper.Map<User>(request.User));

        await Task.CompletedTask;
    }
}
