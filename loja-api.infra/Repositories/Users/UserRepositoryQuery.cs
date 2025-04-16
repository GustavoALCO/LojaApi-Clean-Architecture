using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Users;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Users;

public class UserRepositoryQuery : IUserRepositoryQueries
{
    private readonly ContextDB _db;

    private readonly DbSet<User> _DbUsers;

    public UserRepositoryQuery(ContextDB db)
    {
        _db = db;
        _DbUsers = _db.Users;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync(string? name, int page)
    {
        var Users = await _DbUsers.Where(c => name == null|| c.Name.ToLower().Contains(name.ToLower()))
                                                                                                        .Take(page)
                                                                                                        .ToListAsync();

        return Users;
    }

    public async Task<User> GetUserEmailAsync(string email)
    {
        var User = await _DbUsers.FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());

        return User;
    }

    public async Task<User> GetUserIdAsync(Guid Id)
    {
        var User = await _DbUsers.FindAsync(Id);

        return User;
    }

    public async Task<IEnumerable<User>> UserFilterAsync(IQueryable<User> users, int page)
    {
        var Users = await users.Take(page).ToListAsync();

        return Users;
    }

    public IQueryable<User> UserQuerable()
    {
        return _DbUsers.AsQueryable();
    }
}
