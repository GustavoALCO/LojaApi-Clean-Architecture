using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Queries.User;

public class GetUserID : IRequest<UserDTO>
{
    public Guid UserID { get; set; }
}
