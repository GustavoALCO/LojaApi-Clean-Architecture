using loja_api.domain.Interfaces.Cupom;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Cupom;

public class CupomRepositoryQuery : ICupomRepositoryQuery
{
    private readonly ContextDB _DB;

    public CupomRepositoryQuery(ContextDB dB)
    {
        _DB = dB;
    }

    public async Task<IEnumerable<domain.Entities.Cupom>> GetAllCuponsValid(int page)
    {
        var Cupom = await _DB.Cupom.Where(x => x.IsValid == true).Take(page).ToListAsync();

        return Cupom;
    }

    public async Task<domain.Entities.Cupom> GetCupom(Guid id)
    {
        var Cupom = await _DB.Cupom.FirstOrDefaultAsync(x => x.CupomId == id);

        return Cupom;
    }

    public async Task<domain.Entities.Cupom> GetCupomNameAsync(string name)
    {
        var cupom = await _DB.Cupom.FirstOrDefaultAsync(c => c.Name == name && c.IsValid == true);

        return cupom;
    }

    public async Task<IEnumerable<domain.Entities.Cupom>> GetCuponsFilter(IQueryable<domain.Entities.Cupom> Filter,int page)
    {
        var cupom = await Filter.Take(page).ToListAsync();

        return cupom;
    }

    public IQueryable<domain.Entities.Cupom> GetQuery()
    {
        return _DB.Cupom.AsQueryable();
    }
}
