using System.Linq;
using AutoMapper;
using loja_api.application.Mapper.Cupom;
using loja_api.application.Queries.Cupom;
using loja_api.domain.Interfaces.Cupom;
using MediatR;

namespace loja_api.application.Queries.Handlers.Cupom;

public class GetCupomHandler : IRequestHandler<GetCupomFiltersQuery, IEnumerable<CupomDTO>>
{
    private readonly ICupomRepositoryQuery _query;

    private readonly IMapper _mapper;

    public GetCupomHandler(ICupomRepositoryQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CupomDTO>> Handle(GetCupomFiltersQuery request, CancellationToken cancellationToken)
    {
        var page = request.page;

        page = page * 10;

        var queries = _query.GetQuery();

        if(!string.IsNullOrEmpty(request.Name))
        {
            queries = queries.Where(c => c.Name.ToLower().Contains(request.Name.ToLower()));
        }
        if (request.Discount != null)
        {
            if(request.Discount.Length == 2)
            {
                //Usa p Math para separar as variaveis menores e maiores 
                int min =Math.Min(request.Discount[1], request.Discount[1]);
                int max =Math.Max(request.Discount[0], request.Discount[1]);

                //retorna um intervalo de descontos
                queries = queries.Where(c => c.Discount >=  min && c.Discount <= max);
            }
            if(request.Discount.Length == 1)
            {
                //Se apenas houver 1, retorna o desconto 
                queries = queries.Where(c => c.Discount == request.Discount[0]);
            }
            else
            {
                throw new Exception("Deve se conter no maximo dois valores de desconto");
            }
        }
        if (request.DiscountQuantity != null)
        {
            if (request.DiscountQuantity.Length == 2)
            {
                //Usa p Math para separar as variaveis menores e maiores 
                int min = Math.Min(request.DiscountQuantity[1], request.DiscountQuantity[1]);
                int max = Math.Max(request.DiscountQuantity[0], request.DiscountQuantity[1]);

                //retorna um intervalo de descontos
                queries = queries.Where(c => c.Quantity >= min && c.Quantity <= max);
            }
            if (request.DiscountQuantity.Length == 1)
            {
                //Se apenas houver 1, retorna o desconto 
                queries = queries.Where(c => c.Quantity == request.DiscountQuantity[0]);
            }
            else
            {
                throw new Exception("Deve Conter no maximo dois valores de quantidade");
            }
        }
        if (request.IsValid != null)
        {
            queries = queries.Where(c => c.IsValid == request.IsValid);
        }

        var response = await _query.GetCuponsFilter(queries,page);

        return _mapper.Map<IEnumerable<CupomDTO>>(response);
    }
}
