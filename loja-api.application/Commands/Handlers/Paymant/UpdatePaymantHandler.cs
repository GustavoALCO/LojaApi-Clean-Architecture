using loja_api.application.Commands.Paymant;
using loja_api.application.Interfaces;
using loja_api.domain.Interfaces.Paymants;
using MediatR;

namespace loja_api.application.Commands.Handlers.Paymant;

public class UpdatePaymantHandler : IRequestHandler<UpdatePaymantCommands>
{

    private readonly IpaymantRepositotyQuery _query;

    private readonly IPaymantRepositoryCommands _commands;

    private readonly IUpdateStorage updateStorage;

    public UpdatePaymantHandler(IpaymantRepositotyQuery query, IPaymantRepositoryCommands commands, IUpdateStorage updateStorage)
    {
        _query = query;
        _commands = commands;
        this.updateStorage = updateStorage;
    }

    public async Task Handle(UpdatePaymantCommands request, CancellationToken cancellationToken)
    {
        //Captura as Variaveis inportantes do json 
        string id = request.data.external_reference;
        string type = request.data.type;
        string date = request.data.date;
        string status = request.data.status;

        //Faz Uma chamada ao banco de dados para verificar se o Id passado pelo Json é valido 
        var paymant = await _query.BuscarCompra(Guid.Parse(id));

        //Retorna Nulo se caso for nulo
        if (paymant == null)
            throw new Exception("Paymant não encontrado");

        //Adiciona Informaçoes passadas em uma lista de Assuntos e Datas
        paymant.AttDate.Assunto.Add(status);
        paymant.AttDate.Data.Add(date);

        //Salva as Alteraçoes Feitas
        await _commands.UpdatePaymant(paymant);

        //se o valor de status for approved, deve se retirar do estoque a quantidade de produtos comprados
        if (status.ToLower() == "approved")
        {
           var DltId = paymant.ProductsPaymant.Select(c => c.IdProducts).ToList();
           var dltquantity = paymant.ProductsPaymant.Select(c => c.Quantity).ToList();

            for (int i = 0;  i <= DltId.Count(); i++ )
            {
                await updateStorage.UpdateValuesStorage(DltId[i], dltquantity[i]);            
            }
        }
    }
}
