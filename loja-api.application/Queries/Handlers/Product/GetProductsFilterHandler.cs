using AutoMapper;
using loja_api.application.Mapper.Product;
using loja_api.application.Queries.Product;
using loja_api.domain.Interfaces.products;
using MediatR;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Reflection;

namespace loja_api.application.Queries.Handlers.Product
{
    public class GetProductsFilterHandler : IRequestHandler<GetProductsFilterQuery, IEnumerable<ProductsDTO>>
    {
        private readonly IProductsQueryRepository _repository;
        private readonly IMapper _mapper;

        public GetProductsFilterHandler(IProductsQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // O parâmetro 'request' é do tipo 'GetProductsFilterQuery', e 'request.FilterDTO' é o 'ProductsFilterDTO'
        public async Task<IEnumerable<ProductsDTO>> Handle(GetProductsFilterQuery request, CancellationToken cancellationToken)
        {
            var productsFilter = request.FilterDTO;

            // Definir a página com base no filtro (multiplicado por 10 para calcular o offset)
            var page = productsFilter.page * 10;

            // Criando uma query inicial para buscar produtos
            var query = _repository.GetFilteredQuery();

            // Filtro por Nome do Produto
            if (!string.IsNullOrEmpty(productsFilter.ProductName))
            {
                query = query.Where(c => c.ProductName.ToUpper().Contains(productsFilter.ProductName.ToUpper()));
            }

            // Filtro por Código do Produto
            if (!string.IsNullOrEmpty(productsFilter.CodeProduct))
            {
                query = query.Where(c => c.CodeProduct.ToUpper().Contains(productsFilter.CodeProduct.ToUpper()));
            }

            // Filtro por Tipo do Produto
            if (!string.IsNullOrEmpty(productsFilter.TypeProduct))
            {
                query = query.Where(c => c.TypeProduct.ToUpper() == productsFilter.TypeProduct.ToUpper());
            }

            // Filtro por Preço
            if (productsFilter.Price != null && productsFilter.Price.Count() < 2)
            {
                double price1 = productsFilter.Price[0];
                double price2 = productsFilter.Price[1];

                // Garantir que price1 sempre seja menor que price2
                if (price1 > price2)
                {
                    (price1, price2) = (price2, price1);
                }

                // Filtra os produtos no intervalo entre price1 e price2
                query = query.Where(p => p.Price >= price1 && p.Price <= price2);
            }
            else if (productsFilter.Price != null && productsFilter.Price.Count() == 1)
            {
                // Filtro com apenas um preço selecionado
                query = query.Where(p => p.Price == productsFilter.Price[0]);
            }

            // Executar a consulta e retornar os resultados mapeados para DTOs
            var filteredProducts = await _repository.GetFilterProductsAsync(query, page);

            var queryReturn = _mapper.Map<IEnumerable<ProductsDTO>>(filteredProducts);

            return queryReturn;
        }
    }
}
