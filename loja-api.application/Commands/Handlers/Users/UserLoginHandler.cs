using loja_api.application.Commands.Users;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace loja_api.application.Commands.Handlers.Users;

public class UserLoginHandler : IRequestHandler<UserLoginCommands, string>
{
    private readonly IUserRepositoryQueries _usersRepositoryQueries;

    private readonly IHashService _passwordHasher;

    private readonly IJwtService _jwtService;

    public UserLoginHandler(IUserRepositoryQueries usersRepositoryQueries, IHashService passwordHasher, IJwtService jwtService)
    {
        _usersRepositoryQueries = usersRepositoryQueries;
        _passwordHasher = passwordHasher;
        _jwtService = jwtService;
    }

    public async Task<string> Handle(UserLoginCommands request, CancellationToken cancellationToken)
    {
        var User = await _usersRepositoryQueries.GetUserEmailAsync(request.User.Email);

        if (User == null)
            throw new Exception("Email Não Encontrado");

        var response = _passwordHasher.ValidatePassword(User, request.User.Password, User.Password);

        if (response == false)
            throw new Exception("Senha Incorreta");

       return _jwtService.GerarTokenLogin(User.Email, null);
    }
}
