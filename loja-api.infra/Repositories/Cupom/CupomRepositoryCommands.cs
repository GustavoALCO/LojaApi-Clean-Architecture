using loja_api.domain.Interfaces.Cupom;
using loja_api.infra.Context;

namespace loja_api.infra.Repositories.Cupom;

public class CupomRepositoryCommands : ICupomRepositoryCommands
{
    private readonly ContextDB _DB;

    public CupomRepositoryCommands(ContextDB dB)
    {
        _DB = dB;
    }

    public async Task CreateCupomAsync(domain.Entities.Cupom cupom)
    {
        await _DB.Cupom.AddAsync(cupom);

        await _DB.SaveChangesAsync();
    }

    public async Task UpdateCupomAsync(domain.Entities.Cupom cupom)
    {
        _DB.Cupom.Update(cupom);

        await _DB.SaveChangesAsync();
    }
}
