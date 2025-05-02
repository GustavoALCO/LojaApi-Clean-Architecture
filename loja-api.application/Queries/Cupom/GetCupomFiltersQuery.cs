using loja_api.application.Mapper.Cupom;
using MediatR;

namespace loja_api.application.Queries.Cupom;

public class GetCupomFiltersQuery : IRequest<IEnumerable<CupomDTO>>
{
    public string? Name { get; set; }

    public int[]? Discount { get; set; }

    public int[]? DiscountQuantity { get; set; }

    public bool? IsValid { get; set; }

    public required int page { get; set; }
}
