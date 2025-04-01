using loja_api.domain.Entities.auxiliar;
using System.ComponentModel.DataAnnotations;

namespace loja_api.domain.Entities;

public class Products
{
    [Key]
    public Guid IdProducts { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public string CodeProduct { get; set; }

    public string TypeProduct { get; set; }

    public double Price { get; set; }

    public List<string> Images { get; set; }

    public int QuantityStorage { get; set; }

    public List<ProductsPaymant> ProductsPaymant { get; set; }

    public ICollection<Storages> Storages { get; set; }

    public Auditable Auditable { get; set; }
}
