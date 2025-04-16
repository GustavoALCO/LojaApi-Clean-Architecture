using AutoMapper;
using loja_api.application.Mapper.User;
using loja_api.application.Queries.User;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Queries.Handlers.User;

public class GetAllUsersHandler : IRequestHandler<GetAllUsers, IEnumerable<UserDTO>>
{
    private readonly IUserRepositoryQueries _queries;

    private readonly IMapper _mapper;

    public GetAllUsersHandler(IUserRepositoryQueries queries, IMapper mapper)
    {
        _queries = queries;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> Handle(GetAllUsers request, CancellationToken cancellationToken)
    {
        var page = request.Page;

        if(page < 1)
            page = 1;

        page = page * 10;

        var Users = _mapper.Map<IEnumerable<UserDTO>>(await _queries.GetAllUsersAsync(request.UserName, page));

        if (Users.Count() == null)
            throw new Exception();

        return Users;
    }
}
