using loja_api.domain.Entities.auxiliar;
using System.ComponentModel.DataAnnotations;

namespace loja_api.domain.Entities;

public class Cupom
{
    [Key]
    public Guid CupomId { get; set; }

    public string Name { get; set; }

    public int Discount { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpirationDate { get; set; }

    public Auditable Auditable { get; set; }
}
