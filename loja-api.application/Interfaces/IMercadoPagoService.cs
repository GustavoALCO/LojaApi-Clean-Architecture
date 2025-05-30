using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using loja_api.domain.Entities;
using MercadoPago.Resource.Preference;

namespace loja_api.application.Interfaces;

public interface IMercadoPagoService
{
    Task<Preference> CreatePaymantAsync(Paymant PaymantDTO, User user);

}
