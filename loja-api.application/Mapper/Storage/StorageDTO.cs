using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Mapper.Storage;

public class StorageDTO
{
    public Guid IdStorage { get; set; }

    public Guid IdProducts { get; set; }

    public int Quantity { get; set; }

    public double PriceBuy { get; set; }

    public bool IsValid { get; set; }

    public Auditable Auditable { get; set; }
}
