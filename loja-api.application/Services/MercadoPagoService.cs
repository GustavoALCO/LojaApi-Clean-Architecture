using loja_api.application.Interfaces;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace loja_api.application.Services;

public class MercadoPagoService : IMercadoPagoService
{
    public async Task<Preference> CreatePaymantAsync(PaymantDTO marketCartDTO, UserDTO user)
    {
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
        {

        new PreferenceItemRequest
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Finalizando Compra No Loja-Peças",
            Quantity = marketCartDTO.ProductsMarket.Count,
            CurrencyId = "BRL",
            UnitPrice = ((decimal)marketCartDTO.Price),
        },

    },
            Payer = new PreferencePayerRequest
            {
                DateCreated = DateTime.Now,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
            },
        };

        // Cria a preferência usando o client
        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);

        return preference;
    }

    public async Task<Preference> CreatePaymantSandBoxAsync(PaymantDTO marketCartDTO, UserDTO user)
    {
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
        {

        new PreferenceItemRequest
        {
            Title = "Finalizando Compra No Loja-Peças",
            Quantity = 10,
            CurrencyId = "BRL",
            UnitPrice = ((decimal)marketCartDTO.Price),
        },

    },
            Payer = new PreferencePayerRequest
            {
                DateCreated = DateTime.Now,
                Email = user.Email,
                Name = user.Name,
                Surname = user.Surname,
            },
        };

        // Cria a preferência usando o client
        var client = new PreferenceClient();
        Preference preference = await client.CreateAsync(request);

        return preference;
    }
}
