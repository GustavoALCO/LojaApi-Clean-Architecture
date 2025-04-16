using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Queries.User;

public class GetUserFilter : IRequest<IEnumerable<UserDTO>>
{
    public UserFilterDTO Filter { get; set; }
}
