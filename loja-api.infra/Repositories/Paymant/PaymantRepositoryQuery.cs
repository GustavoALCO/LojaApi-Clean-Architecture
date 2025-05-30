using loja_api.domain.Interfaces.Paymants;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Paymant;

public class PaymantRepositoryQuery : IpaymantRepositotyQuery
{

    private readonly ContextDB _contextDB;

    public PaymantRepositoryQuery(ContextDB contextDB)
    {
        _contextDB = contextDB;

    }

    public async Task<domain.Entities.Paymant> BuscarCompra(Guid id)
    {
        var Paymant = await _contextDB.Paymant.FirstOrDefaultAsync(x => x.PaymantId == id);

        return Paymant;
    }

    public async Task<IEnumerable<domain.Entities.Paymant>> BuscarCompraFiltro(IQueryable<domain.Entities.Paymant> query, int page)
    {
        var Paymant = await query.Take(page).ToListAsync();

        return Paymant;
    }

    public async Task<IEnumerable<domain.Entities.Paymant>> BuscarTodasAsCompras(int page)
    {
        var Paymant = await _contextDB.Paymant.Take(page).ToListAsync();

        return Paymant;
    }

    public async Task<IEnumerable<domain.Entities.Paymant>> BuscarTodasAsComprasUser(Guid Id, int page)
    {
        var Paymant = await _contextDB.Paymant.Where(x => x.IdUser == Id).Take(page).ToListAsync();

        return Paymant;
    }

    public IQueryable<domain.Entities.Paymant> GetQuery()
    {
        return _contextDB.Paymant.AsQueryable();
    }
}
