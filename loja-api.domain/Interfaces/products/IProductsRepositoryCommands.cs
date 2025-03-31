using loja_api.domain.Entities;

namespace loja_api.domain.Interfaces.products;

public interface IProductsRepositoryCommands
{

    //Cria produto passando product como parametro
    Task CreateProductsAsync(Products products);

    //Altera produto passando product como parametro
    Task UpdateProductsAsync(Products products);

    //Deleta produto passando id como parametro
    Task DeleteProductsAsync(Products products);
}
