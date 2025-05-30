using loja_api.application.Interfaces;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using loja_api.domain.Entities;
using MercadoPago.Client.Preference;
using MercadoPago.Resource.Preference;

namespace loja_api.application.Services;

public class MercadoPagoService : IMercadoPagoService
{
    public async Task<Preference> CreatePaymantAsync(Paymant PaymantDTO, User user)
    {
        var request = new PreferenceRequest
        {
            Items = new List<PreferenceItemRequest>
        {

        new PreferenceItemRequest
        {
            Id = Guid.NewGuid().ToString(),
            Title = "Finalizando Compra No Loja-Peças",
            Quantity = PaymantDTO.ProductsPaymant.Count,
            CurrencyId = "BRL",
            UnitPrice = (decimal)PaymantDTO.Price,
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
