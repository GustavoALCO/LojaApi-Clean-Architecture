using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using MercadoPago.Resource.Preference;

namespace loja_api.application.Interfaces;

public interface IMercadoPagoService
{
    Task<Preference> CreatePaymantAsync(PaymantDTO marketCartDTO, UserDTO user);

    Task<Preference> CreatePaymantSandBoxAsync(PaymantDTO marketCartDTO, UserDTO user);
}
