using AutoMapper;
using loja_api.application.Mapper.Product;
using loja_api.domain.Entities;
using loja_api.domain.Interfaces.products;
using loja_api.infra.Context;
using Microsoft.EntityFrameworkCore;

namespace loja_api.infra.Repositories.Product;

public class ProductsRepositoryCommands : IProductsRepositoryCommands
{
    private readonly ContextDB _DB;
    private readonly DbSet<Products> _DBProducts;

    public ProductsRepositoryCommands(ContextDB dB)
    {
        _DB = dB;
        _DBProducts = dB.Products;
    }

    public async Task CreateProductsAsync(Products products)
    {
        //Adiciona produtos no banco de dados
        await _DBProducts.AddAsync(products);
        //Salva os produtos no banco de dados
        await _DB.SaveChangesAsync();
    }

    public async Task DeleteProductsAsync(Products products)
    {
        //Passa os parametros de Produtos para a exclusão do banco de dados
        _DBProducts.Remove(products);
        //Salva no banco de dados
        await _DB.SaveChangesAsync();
    }

    public async Task UpdateProductsAsync(Products productsUpdate)
    {
        var product = _DBProducts.Update(productsUpdate);

        await _DB.SaveChangesAsync();
    }
}
