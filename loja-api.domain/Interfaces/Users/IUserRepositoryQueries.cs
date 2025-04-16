using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Users;

public interface IUserRepositoryQueries
{
    public Task<User> GetUserIdAsync(Guid Id);

    public Task<IEnumerable<User>> GetAllUsersAsync(string? name, int page);

    public Task<User> GetUserEmailAsync(string email);

    public Task<IEnumerable<User>> UserFilterAsync(IQueryable<User> users, int page);

    public IQueryable<User> UserQuerable();
}
