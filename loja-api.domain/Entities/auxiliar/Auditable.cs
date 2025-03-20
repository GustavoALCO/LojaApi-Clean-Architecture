namespace loja_api.domain.Entities.auxiliar;

public class Auditable
{
    public int CreatebyId { get; set; }

    public DateTime CreateDate { get; set; }

    public int UpdatebyId { get; set; }

    public DateTime UpdateDate { get; set; }
}
