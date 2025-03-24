using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Profiles;

public class PaymantProfile : Profile
{
    public PaymantProfile()
    {
        CreateMap<Paymant, PaymantDTO>()
            .ForMember(dest => dest.ProductsMarket, opt => opt.MapFrom(src => src.ProductsPaymant
            .Select(mp => new ProductsPaymant
            {
                IdProducts = mp.Products.IdProducts,
                Price = mp.Products.Price,
                Quantity = mp.Quantity
            }).ToList()));
    }
}