using loja_api.domain.Entities.auxiliar;
using System.ComponentModel.DataAnnotations;

namespace loja_api.domain.Entities;

public class Paymant
{
    [Key]
    public Guid PaymantId { get; set; }

    public Guid IdUser { get; set; }

    public Guid? CupomId { get; set; }

    public List<ProductsPaymant> ProductsPaymant { get; set; }

    public double Price { get; set; }

    public Attdata AttDate { get; set; }

    public User User { get; set; }

    public Cupom Cupom { get; set; }
}
