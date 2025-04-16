using loja_api.domain.Interfaces.Paymants;
using loja_api.infra.Context;

namespace loja_api.infra.Repositories.Paymant;

public class PaymantRepositoryCommands : IPaymantRepositoryCommands
{
    private readonly ContextDB _contextDB;

    public PaymantRepositoryCommands(ContextDB contextDB)
    {
        _contextDB = contextDB;

    }

    public async Task CreatePaymant(domain.Entities.Paymant paymant)
    {
        _contextDB.Paymant.Add(paymant);    
        
        await _contextDB.SaveChangesAsync();
    }

    public async Task UpdatePaymant(domain.Entities.Paymant paymant)
    {
        _contextDB.Paymant.Update(paymant);

        await _contextDB.SaveChangesAsync();
    }
}
