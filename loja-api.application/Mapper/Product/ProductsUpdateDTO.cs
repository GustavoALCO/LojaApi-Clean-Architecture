﻿namespace loja_api.application.Mapper.Product;

public class ProductsUpdateDTO
{
    public Guid IdProducts { get; set; }

    public string ProductName { get; set; }

    public string ProductDescription { get; set; }

    public string CodeProduct { get; set; }

    public string TypeProduct { get; set; }

    public double Price { get; set; }

    public int UserUpdate { get; set; }

    public DateTime DateUpdate { get; set; }
}
