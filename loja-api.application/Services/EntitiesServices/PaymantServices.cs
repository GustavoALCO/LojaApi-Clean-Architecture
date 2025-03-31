/*using AutoMapper;
using loja_api.application.Interfaces.Entities;
using loja_api.application.Mapper.Employee;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using loja_api.application.Services.AuxiliarServices;
using loja_api.domain.Entities;
using MercadoPago.Resource.Preference;
using Microsoft.Extensions.Logging;

namespace loja_api.application.Services.EntitiesServices;

public class PaymantServices 
{
    private readonly IGenericService<PaymantDTO,Paymant> _PaymantRepository;

    private readonly IGenericService<UserDTO, User> _UserRepository;

    private readonly IMapper _mapper;

    private readonly ILogger _logger;

    private readonly MercadoPagoService _mercadoPagoService;

    public PaymantServices(IGenericService<PaymantDTO, Paymant> PaymantRepository,
                           IGenericService<UserDTO, User> UserRepository,
                           IMapper mapper, ILogger<EmployeeDTO> logger,
                           HashService hashService,
                           MercadoPagoService mercadoPagoService
        )
    {
        _mapper = mapper;
        _logger = logger;
        _mercadoPagoService = mercadoPagoService;
        _PaymantRepository = PaymantRepository;
        _UserRepository = UserRepository;
    }

    public async Task<string?> CreatePaymant(PaymantDTO paymant)
    {

        try
        {
            //Busca no Banco de dados para verificar se o Usuario Existe
            UserDTO user = (await _UserRepository.GetByIdAsync(paymant.UserId));

            //Se Não for achado retorna Null
            if (user == null)
                return null;

            //Caso Encontre, Será adicionado uma String e a data atual do processo no AttDate
            paymant.AttDate.Assunto.Add("Pedido Realizado");
            paymant.AttDate.Data.Add(DateTime.UtcNow.ToString());

            //Cria um request para o mercadoPago criar uma preferencia para a compra do Usuario, e retorna um Corpo com as preferencias.
            var url = await _mercadoPagoService.CreatePaymantAsync(paymant, user);

            //Recebe o Id das preferencias para Criar o pagamento no banco de dados
            paymant.MarketCartId = url.Id;

            //Chama a interface para criar o pagamento no banco de dados
            await _PaymantRepository.AddAsync(paymant);

            //Retorna o URL para o usuario efetuar o pagamento
            return url.SandboxInitPoint.ToString();


        }
        catch (Exception ex)
        {
            return $"{ex.Message}";
        }
    }
    //Passa os valores de Usuario e Paymant para a Criação de uma preferencia do mercado pago e retorna a stringUrl do InitPoint (pagamento)

    public async Task<Preference> CreatePaymantTest()
    {
        UserDTO user = new UserDTO
        {
            Email = "Teste@gmail.com",
            Name = "TesteUser",
            Surname = "test"
        };

        // Criando um carrinho fictício
        PaymantDTO market = new PaymantDTO
        {
            Price = 100,
        };
        try
        {
            var url = await _mercadoPagoService.CreatePaymantSandBoxAsync(market, user);

            return url;
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.Message}");
            return null;
        }
    }
    //Cria Usuarios e valores fixo para teste e retorna uma preferencia do mercadopago

    public async Task<bool> RecibeWebHook(dynamic data)
    {
        //Captura as Variaveis inportantes do json 
        string id = data.id;
        string type = data.type;
        string date = data.date_created;

        //Faz Uma chamada ao banco de dados para verificar se o Id passado pelo Json é valido 
        PaymantDTO paymant = await _PaymantRepository.GetByIdAsync(id);

        //Retorna Nulo se caso for nulo
        if (paymant == null)
            return false;

        //Adiciona Informaçoes passadas em uma lista de Assuntos e Datas
        paymant.AttDate.Assunto.Add(type);
        paymant.AttDate.Data.Add(date);

        //Salva as Alteraçoes Feitas
        await _PaymantRepository.UpdateAsync(paymant);

        //Retorna True para ser tratado no Endpoint
        return true;
    }
    //Recebe o Hook com a resposta do pagamento
}
*/