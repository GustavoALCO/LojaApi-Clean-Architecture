using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Mapper.Cupom;

public class CupomDTO
{
    public Guid CupomId { get; set; }

    public string Name { get; set; }

    public int Discount { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpirationDate { get; set; }

    public Auditable Auditable { get; set; }

}
