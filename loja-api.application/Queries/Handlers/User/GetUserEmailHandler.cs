using AutoMapper;
using loja_api.application.Mapper.User;
using loja_api.application.Queries.User;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Queries.Handlers.User;

public class GetUserEmailHandler : IRequestHandler<GetUserEmail, UserDTO>
{
    private readonly IUserRepositoryQueries _userRepositoryQueries;

    private readonly IMapper _mapper;

    public GetUserEmailHandler(IMapper mapper, IUserRepositoryQueries userRepositoryQueries)
    {
        _mapper = mapper;
        _userRepositoryQueries = userRepositoryQueries;
    }

    public async Task<UserDTO> Handle(GetUserEmail request, CancellationToken cancellationToken)
    {
        return _mapper.Map<UserDTO>(await _userRepositoryQueries.GetUserEmailAsync(request.Email));
    }
}
