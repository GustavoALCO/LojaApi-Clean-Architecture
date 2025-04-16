using loja_api.application.Mapper.Employee;
using MediatR;

namespace loja_api.application.Queries.Employee;

public class GetEmployeeIdQueries : IRequest<EmployeeDTO>
{
    public int Id { get; set; }
}
