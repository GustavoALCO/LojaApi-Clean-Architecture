using loja_api.domain.Interfaces.Employee;
using loja_api.infra.Context;

namespace loja_api.infra.Repositories.Employee;

public class EmployeeRepositoryCommands : IEmployeeRepositoryCommands
{
    private readonly ContextDB _context;

    public EmployeeRepositoryCommands(ContextDB context)
    {
        _context = context;
    }

    public async Task CreateEmployeeAsync(domain.Entities.Employee employee)
    {
        await _context.Employee.AddAsync(employee);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateEmployeeAsync(domain.Entities.Employee employee)
    {
        _context.Employee.Update(employee);

        await _context.SaveChangesAsync();
    }
}
