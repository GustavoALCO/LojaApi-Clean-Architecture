using System.ComponentModel.DataAnnotations;

namespace loja_api.application.Mapper.Product;

public class ProductsCreateDTO
{

    [Required]
    public string ProductName { get; set; }

    [Required]
    public string ProductDescription { get; set; }

    public string CodeProduct { get; set; }

    [Required]
    public string TypeProduct { get; set; }

    [Required]
    public double Price { get; set; }

    public List<string> Images { get; set; }

    public int UserCreate {  get; set; }

}
