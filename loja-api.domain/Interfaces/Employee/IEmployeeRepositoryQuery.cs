using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Employee;

public interface IEmployeeRepositoryQuery
{

    public Task<Entities.Employee> GetEmployeeIDAsync(int Id);


    public Task<Entities.Employee> GetEmployeeLoginAsync(string login);

    public Task<IEnumerable<Entities.Employee>> GetAllEmployeeAsync(int page);

    public Task<IEnumerable<Entities.Employee>> GetEmployeeFilter(IQueryable<Entities.Employee> query, int page);

    public IQueryable<Entities.Employee> GetQuery();
}
