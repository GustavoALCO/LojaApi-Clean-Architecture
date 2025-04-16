using loja_api.application.Commands.Paymant;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Commands.Handlers.Paymant;

public class UpdatePaymantHandler : IRequestHandler<UpdatePaymantCommands>
{

    private readonly IpaymantRepositotyQuery _query;

    private readonly IPaymantRepositoryCommands _commands;

    public UpdatePaymantHandler(IpaymantRepositotyQuery query, IPaymantRepositoryCommands commands)
    {
        _query = query;
        _commands = commands;
    }

    public async Task Handle(UpdatePaymantCommands request, CancellationToken cancellationToken)
    {
        //Captura as Variaveis inportantes do json 
        string id = request.data.id;
        string type = request.data.type;
        string date = request.data.date_created;

        //Faz Uma chamada ao banco de dados para verificar se o Id passado pelo Json é valido 
        var paymant = await _query.BuscarCompra(id);

        //Retorna Nulo se caso for nulo
        if (paymant == null)
            throw new Exception("Paymant não encontrado");

        //Adiciona Informaçoes passadas em uma lista de Assuntos e Datas
        paymant.AttDate.Assunto.Add(type);
        paymant.AttDate.Data.Add(date);

        //Salva as Alteraçoes Feitas
        await _commands.UpdatePaymant(paymant);
    }
}
