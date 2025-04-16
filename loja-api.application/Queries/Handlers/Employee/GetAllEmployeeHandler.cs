using AutoMapper;
using loja_api.application.Mapper.Employee;
using loja_api.application.Queries.Employee;
using loja_api.domain.Interfaces.Employee;
using MediatR;

namespace loja_api.application.Queries.Handlers.Employee;

public class GetAllEmployeeHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<EmployeeDTO>>
{
    private readonly IEmployeeRepositoryQuery _query;

    private readonly IMapper _mapper;

    public GetAllEmployeeHandler(IEmployeeRepositoryQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EmployeeDTO>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = _mapper.Map<IEnumerable<EmployeeDTO>>(await _query.GetAllEmployeeAsync(request.page));

        return employee;
    }
} 
