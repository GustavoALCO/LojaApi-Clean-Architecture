using AutoMapper;
using loja_api.application.Mapper.Paymant;
using loja_api.application.Mapper.Paymant.ProductsPaymant;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Profiles;

public class PaymantProfile : Profile
{
    public PaymantProfile()
    {
        CreateMap<Paymant, PaymantDTO>()
            .ForMember(dest => dest.ProductsPaymants, opt => opt.MapFrom(src => src.ProductsPaymant
                .Select(mp => new domain.Entities.auxiliar.ProductsPaymant
                {
                    IdProducts = mp.IdProducts,
                    Quantity = mp.Quantity
                }).ToList()));
    }
}
