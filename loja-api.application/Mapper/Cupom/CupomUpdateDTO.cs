﻿namespace loja_api.application.Mapper.Cupom;

public class CupomUpdateDTO
{
    public string Name { get; set; }

    public int Discount { get; set; }

    public int Quantity { get; set; }

    public DateTime ExpirationDate { get; set; }

    public int UpdatebyId { get; set; }

    public DateTime UpdateDate { get; set; }
}
