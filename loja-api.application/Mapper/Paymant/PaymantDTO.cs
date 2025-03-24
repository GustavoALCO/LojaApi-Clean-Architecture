using loja_api.application.Mapper.Paymant.ProductsPaymant;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Mapper.Paymant;

public class PaymantDTO
{
    public string MarketCartId { get; set; }

    public Guid UserId { get; set; }

    public Guid CupomId { get; set; }

    public List<ProductsPaymantDTO> ProductsMarket { get; set; }

    public double Price { get; set; }

    public string Paymant { get; set; }

    public Attdata AttDate { get; set; }
}
