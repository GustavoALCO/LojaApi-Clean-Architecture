using loja_api.domain.Entities;
using loja_api.domain.Interfaces.products;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Product;

public class ProductsRepositoryQueries : IProductsQueryRepository
{
    private readonly ContextDB _DB;
    private readonly DbSet<Products> _DBProducts;

    public ProductsRepositoryQueries(ContextDB dB)
    {
        _DB = dB;
        _DBProducts = dB.Products;
    }

    public async Task<Products> GetProductsIDAsync(Guid id)
    {
        //Faz Busca no Banco de dados pelo Id 
        var product = await _DBProducts.FindAsync(id);

        //Retorna Produtos
        return product;
    }

    public async Task<IEnumerable<Products>> GetAllProductsAsync(string name, int page)
    {
        //Define a variavel Page para retornar o valor da pagina multiplicado por 10 
        page = page * 10;

        //Faz a busca e retorna no banco de dados se conter as mesmas pavras ou se não for passar nenhum valor
        var products = await _DBProducts.Where(p => name == null || p.ProductName.ToUpper().Contains(name.ToUpper()))
                                                                                                              //Retorna a quantidade de valor da pagina * 10
                                                                                                              .Take(page)
                                                                                                              //Lista todos os Produtos de forma Async
                                                                                                              .ToListAsync();

        return products;
    }

    public async Task<IEnumerable<Products>> GetFilterProductsAsync(IQueryable<Products> query, int page)
    {
        //Define a variavel Page para retornar o valor da pagina multiplicado por 10 
        page = page * 10;

        var queryReturn = await query.Take(page).ToListAsync();

        return queryReturn;
    }

    public IQueryable<Products> GetFilteredQuery()
    {
        return _DBProducts.AsQueryable();
    }
}
