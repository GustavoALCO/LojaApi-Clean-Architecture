using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Employee;

public interface IEmployeeRepositoryCommands
{
    public Task CreateEmployeeAsync(domain.Entities.Employee employee);

    public Task UpdateEmployeeAsync(domain.Entities.Employee employee);
}
