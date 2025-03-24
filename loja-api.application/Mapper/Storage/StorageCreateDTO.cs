namespace loja_api.application.Mapper.Storage;

public class StorageCreateDTO
{
    public Guid IdStorage { get; set; }

    public Guid IdProducts { get; set; }

    public int Quantity { get; set; }

    public double PriceBuy { get; set; }

    public int CreatebyId { get; set; }

    public bool IsValid { get; set; }

    public DateTime CreateDate { get; set; }
}
