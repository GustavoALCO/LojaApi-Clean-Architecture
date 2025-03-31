using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.products;

public interface IProductsQueryRepository
{
    //Busca o produto pelo ID especifico
    Task<Products> GetProductsIDAsync(Guid id);

    //Busca todos os produtos, com um limite de 10 produtos por pagina 
    Task<IEnumerable<Products>> GetAllProductsAsync(string? name, int page);

    //Busca produtos por filtro, com limite de 10 produtos por pagina
    Task<IEnumerable<Products>> GetFilterProductsAsync(IQueryable<Products> products, int page);

    //Retorna uma IQuerable para Conseguir montar o Filtro
    public IQueryable<Products> GetFilteredQuery();
}
