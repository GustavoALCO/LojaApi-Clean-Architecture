using loja_api.application.Mapper.User;
using MediatR;

namespace loja_api.application.Queries.User;

public class GetAllUsers : IRequest<IEnumerable<UserDTO>>
{
    public string UserName { get; set; }

    public int Page {  get; set; }
}
