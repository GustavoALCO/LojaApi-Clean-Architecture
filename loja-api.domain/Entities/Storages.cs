using loja_api.domain.Entities.auxiliar;
using System.ComponentModel.DataAnnotations;

namespace loja_api.domain.Entities;

public class Storages
{
    [Key]
    public Guid IdStorage { get; set; }

    public Guid IdProducts { get; set; }

    public int Quantity { get; set; }

    public double PriceBuy { get; set; }

    public bool IsValid { get; set; }

    public Products Products { get; set; }

    public Auditable Auditable { get; set; }
}