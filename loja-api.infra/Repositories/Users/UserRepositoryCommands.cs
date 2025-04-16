using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Users;
using loja_api.infra.Context;

namespace loja_api.infra.Repositories.Users;

public class UserRepositoryCommands : IUserRepositoryCommands
{
    private readonly ContextDB _DB;
public UserRepositoryCommands(ContextDB dB)
    {
        _DB = dB;
    }

    public async Task CreateUser(User user)
    {
        //Adiciona ao Banco de dados
        await _DB.Users.AddAsync(user);
        //Salva as Alteraçoes
        _DB.SaveChanges();
    }

    public Task DeleteUser(User user)
    {
        _DB.Users.Remove(user);

        _DB.SaveChanges();

        return Task.CompletedTask;
    }

    public Task UpdateUser(User user)
    {
        _DB.Users.Update(user);

        _DB.SaveChangesAsync();

        return Task.CompletedTask;
    }
}
