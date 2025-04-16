using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.Cupom;

public interface ICupomRepositoryQuery
{
    public Task<IEnumerable<Entities.Cupom>> GetAllCuponsValid(int page);

    public Task<Entities.Cupom> GetCupom( Guid id);

    public Task<IEnumerable<Entities.Cupom>> GetCuponsFilter(IQueryable<Entities.Cupom> Filter, int page);

    public IQueryable<Entities.Cupom> GetQuery();
}
