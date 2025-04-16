using AutoMapper;
using loja_api.application.Mapper.Employee;
using loja_api.application.Queries.Employee;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Queries.Handlers.Employee;

public class GetEmployeeIdHandler : IRequestHandler<GetEmployeeIdQueries, EmployeeDTO>
{
    private readonly IEmployeeRepositoryQuery _query;

    private readonly IMapper _mapper;

    public GetEmployeeIdHandler(IMapper mapper, IEmployeeRepositoryQuery query)
    {
        _mapper = mapper;
        _query = query;
    }

    public async Task<EmployeeDTO> Handle(GetEmployeeIdQueries request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<EmployeeDTO>(await _query.GetEmployeeIDAsync(request.Id));

        return employee;
    }
}
