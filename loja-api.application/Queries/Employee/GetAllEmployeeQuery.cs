using loja_api.application.Mapper.Employee;
using MediatR;

namespace loja_api.application.Queries.Employee;

public class GetAllEmployeeQuery : IRequest<IEnumerable<EmployeeDTO>>
{
    public int page;
}
