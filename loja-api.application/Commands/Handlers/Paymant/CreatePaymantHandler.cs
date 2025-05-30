using AutoMapper;
using loja_api.application.Commands.Paymant;
using loja_api.application.Interfaces;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;
using loja_api.domain.Interfaces.Cupom;
using loja_api.domain.Interfaces.Paymants;
using loja_api.domain.Interfaces.products;
using loja_api.domain.Interfaces.Users;
using MediatR;
using MediatR.NotificationPublishers;

namespace loja_api.application.Commands.Handlers.Paymant;

public class CreatePaymantHandler : IRequestHandler<CreatePaymantCommands, string>
{
    private readonly IpaymantRepositotyQuery _query;

    private readonly IPaymantRepositoryCommands _commands;

    private readonly IUserRepositoryQueries _users;

    private readonly IProductsQueryRepository _products;

    private readonly ICupomRepositoryQuery _cupom;

    private readonly IMercadoPagoService _mercadoPagoService;

    private readonly IMapper _mapper;

    public CreatePaymantHandler(IPaymantRepositoryCommands commands, IpaymantRepositotyQuery query, IUserRepositoryQueries users, IMercadoPagoService mercadoPagoService, IMapper mapper, IProductsQueryRepository products, ICupomRepositoryQuery cupom)
    {
        _commands = commands;
        _query = query;
        _users = users;
        _mercadoPagoService = mercadoPagoService;
        _mapper = mapper;
        _products = products;
        _cupom = cupom;
    }

    public async Task<string> Handle(CreatePaymantCommands request, CancellationToken cancellationToken)
    {
        
            //Busca no Banco de dados para verificar se o Usuario Existe
            User user = await _users.GetUserIdAsync(request.UserId);

            //Se Não for achado retorna Null
            if (user == null)
                throw new Exception("Usuario não encontrado");

            //Atribui o valor do DTO para a entidade Entity
        var paymant = new domain.Entities.Paymant
        {
            IdUser = request.UserId,
            CupomId = request.CupomId,
            ProductsPaymant = request.ProductsMarket
                                     .Select(p => new ProductsPaymant
                                     {
                                         IdProducts = p.IdProducts,
                                         Quantity = p.Quantity
                                     }).ToList(),
            AttDate = new Attdata
            {
                Assunto = new List<string>(),
                Data = new List<string>()
            }
        };

        foreach (var product in request.ProductsMarket)
        {

            var productData = await _products.GetProductsIDAsync(product.IdProducts);

            paymant.Price += productData.Price;
        }

        if (request.CupomId != null)
        {
            var cupomData = await _cupom.GetCupom(request.CupomId);
            var discountRate = cupomData.Discount / 100.0;
            paymant.Price = paymant.Price * (1 - discountRate);
        }

        //Caso Encontre, Será adicionado uma String e a data atual do processo no AttDate
        paymant.AttDate.Assunto.Add("Pedido Realizado");
            paymant.AttDate.Data.Add(DateTime.UtcNow.ToString());

        paymant.PaymantId = Guid.NewGuid();

        //Cria um request para o mercadoPago criar uma preferencia para a compra do Usuario, e retorna um Corpo com as preferencias.
        var url = await _mercadoPagoService.CreatePaymantAsync(paymant, user);

            //Recebe o Id das preferencias para Criar o pagamento no banco de dados
            

            //Chama a interface para criar o pagamento no banco de dados
            await _commands.CreatePaymant(paymant);

            //Retorna o URL para o usuario efetuar o pagamento
            return url.SandboxInitPoint.ToString();


        
    
    }
}
