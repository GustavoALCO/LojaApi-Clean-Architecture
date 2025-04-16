using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Queries.User;

public class GetUserEmail : IRequest<UserDTO>
{
    public string Email { get; set; }
}
