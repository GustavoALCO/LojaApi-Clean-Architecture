using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Users;

public interface IUserRepositoryCommands
{
    public Task CreateUser(User user);

    public Task DeleteUser(User user);

    public Task UpdateUser(User user);

}
