using AutoMapper;
using loja_api.application.Commands.Users;
using loja_api.application.Interfaces.Auxiliar;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Users;

public class CreateUsersHandlers : IRequestHandler<CreateUsersCommon>
{
    private readonly IUserRepositoryCommands _userRepositoryCommands;

    private readonly IUserRepositoryQueries _userRepositoryQueries;

    private readonly IHashService _hashService;

    private readonly IMapper _mapper;

    public CreateUsersHandlers(IUserRepositoryQueries userRepositoryQueries, IUserRepositoryCommands userRepositoryCommands, IMapper mapper, IHashService hashService)
    {
        _userRepositoryQueries = userRepositoryQueries;
        _userRepositoryCommands = userRepositoryCommands;
        _mapper = mapper;
        _hashService = hashService;
    }

    public async Task Handle(CreateUsersCommon request, CancellationToken cancellationToken)
    {

        var user = _userRepositoryQueries.GetUserEmailAsync(request.User.Email);

        if (user == null)
            throw new Exception("Usuario já criado com este email");

        request.User.IsValid = true;

        request.User.Password = _hashService.CreateHash(request.User, request.User.Password);

        await _userRepositoryCommands.CreateUser(_mapper.Map<User>(request.User));

        await Task.CompletedTask;
    }
}
