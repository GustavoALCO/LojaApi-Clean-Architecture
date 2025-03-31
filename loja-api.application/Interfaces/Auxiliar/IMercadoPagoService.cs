using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.User;
using loja_api.domain.Entities;
using MercadoPago.Resource.Preference;

namespace loja_api.application.Interfaces.Auxiliar;

public interface IMercadoPagoService
{
    Task<Preference> CreatePaymantAsync(PaymantDTO PaymantDTO, UserDTO user);

    Task<Preference> CreatePaymantSandBoxAsync(PaymantDTO PaymantDTO, UserDTO user);
}
