using MediatR;

namespace loja_api.application.Commands.Users;

public class DeleteUserCommands : IRequest
{
   public Guid Id { get; set; }
}
