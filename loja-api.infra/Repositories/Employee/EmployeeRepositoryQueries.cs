using loja_api.domain.Interfaces.Employee;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Employee;

public class EmployeeRepositoryQueries : IEmployeeRepositoryQuery
{
    private readonly ContextDB _context;

    public EmployeeRepositoryQueries(ContextDB context)
    {
        _context = context;
    }

    public async Task<IEnumerable<domain.Entities.Employee>> GetAllEmployeeAsync(int page)
    {
        return await _context.Employee.Take(page).ToListAsync();
    }

    public async Task<IEnumerable<domain.Entities.Employee>> GetEmployeeFilter(IQueryable<domain.Entities.Employee> query, int page)
    {
        return await query.Take(page).ToListAsync();
    }

    public async Task<domain.Entities.Employee> GetEmployeeIDAsync(int Id)
    {
        var employee = await _context.Employee.FirstOrDefaultAsync(x => x.Id == Id);

        return employee;
    }

    public IQueryable<domain.Entities.Employee> GetQuery()
    {
        return _context.Employee.AsQueryable();
    }

    public async Task<domain.Entities.Employee> GetEmployeeLoginAsync(string login)
    {
        return await _context.Employee.FirstOrDefaultAsync(x => x.Login.ToLower() == login.ToLower());
    }
}
