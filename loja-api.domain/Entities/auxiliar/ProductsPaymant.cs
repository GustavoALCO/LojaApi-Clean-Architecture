namespace loja_api.domain.Entities.auxiliar;

public class ProductsPaymant
{
    public Guid MarketCartId { get; set; }

    public Guid IdProducts { get; set; }

    public int Quantity { get; set; }

    public double Price { get; set; }

    public Products Products { get; set; }

    public Paymant Paymant { get; set; }
}
