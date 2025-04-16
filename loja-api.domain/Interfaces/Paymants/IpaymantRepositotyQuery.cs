using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Paymants;

public interface IpaymantRepositotyQuery
{
    public Task<IEnumerable<Paymant>> BuscarTodasAsCompras(int page);

    public Task<IEnumerable<Paymant>> BuscarTodasAsComprasUser(Guid Id, int page);

    public Task<IEnumerable<Paymant>> BuscarCompraFiltro(IQueryable<Paymant> query, int page);

    public Task<Paymant> BuscarCompra(string id);

    public IQueryable<Paymant> GetQuery();
}
