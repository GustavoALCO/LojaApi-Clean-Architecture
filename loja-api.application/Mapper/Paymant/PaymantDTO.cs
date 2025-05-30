namespace loja_api.application.Mapper.Paymant;

public class PaymantDTO
{
    public required Guid IdUser { get; set; }

    public Guid CupomId { get; set; }

    public required List<domain.Entities.auxiliar.ProductsPaymant> ProductsPaymants { get; set; }

}
