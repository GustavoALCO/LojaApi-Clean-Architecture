using AutoMapper;
using loja_api.application.Commands.Paymant;
using loja_api.application.Interfaces;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.Paymants;
using loja_api.domain.Interfaces.Users;
using MediatR;

namespace loja_api.application.Commands.Handlers.Paymant;

public class CreatePaymantHandler : IRequestHandler<CreatePaymantCommands, string>
{
    private readonly IpaymantRepositotyQuery _query;

    private readonly IPaymantRepositoryCommands _commands;

    private readonly IUserRepositoryQueries _users;

    private readonly IMercadoPagoService _mercadoPagoService;

    private readonly IMapper _mapper;

    public CreatePaymantHandler(IPaymantRepositoryCommands commands, IpaymantRepositotyQuery query, IUserRepositoryQueries users, IMercadoPagoService mercadoPagoService, IMapper mapper)
    {
        _commands = commands;
        _query = query;
        _users = users;
        _mercadoPagoService = mercadoPagoService;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreatePaymantCommands request, CancellationToken cancellationToken)
    {
        try
        {
            //Busca no Banco de dados para verificar se o Usuario Existe
            User user = await _users.GetUserIdAsync(request.PaymantDTO.UserId);

            //Se Não for achado retorna Null
            if (user == null)
                throw new Exception("Usuario não encontrado");

            var paymant = _mapper.Map<domain.Entities.Paymant>(request.PaymantDTO);

            //Caso Encontre, Será adicionado uma String e a data atual do processo no AttDate
            paymant.AttDate.Assunto.Add("Pedido Realizado");
            paymant.AttDate.Data.Add(DateTime.UtcNow.ToString());

            //Cria um request para o mercadoPago criar uma preferencia para a compra do Usuario, e retorna um Corpo com as preferencias.
            var url = await _mercadoPagoService.CreatePaymantAsync(paymant, user);

            //Recebe o Id das preferencias para Criar o pagamento no banco de dados
            request.PaymantDTO.MarketCartId = url.Id;

            //Chama a interface para criar o pagamento no banco de dados
            await _commands.CreatePaymant(paymant);

            //Retorna o URL para o usuario efetuar o pagamento
            return url.SandboxInitPoint.ToString();


        }
        catch (Exception ex)
        {
            return $"{ex.Message}";
        }
    }
}
