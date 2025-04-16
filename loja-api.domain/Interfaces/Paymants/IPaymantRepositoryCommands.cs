using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Paymants;

public interface IPaymantRepositoryCommands
{
    public Task CreatePaymant(Paymant paymant);

    public Task UpdatePaymant(Paymant paymant);
}
