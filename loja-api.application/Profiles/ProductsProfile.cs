using AutoMapper;
using loja_api.application.Mapper.Product;
using loja_api.application.Services;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Profiles;

public class ProductsProfile : Profile
{
    public ProductsProfile()
    {
        CreateMap<Products, ProductsDTO>().ReverseMap();

        CreateMap<Products, ProductsFilterDTO>().ReverseMap();

        CreateMap<Products, ProductsCreateDTO>()
            .ForMember(dest => dest.UserCreate, opt => opt.MapFrom(src => src.Auditable.CreatebyId))
            .ReverseMap();

        CreateMap<Products, ProductsUpdateDTO>()
    .ForMember(dest => dest.DateUpdate, opt => opt.MapFrom(src => src.Auditable.UpdateDate))
    .ForMember(dest => dest.UserUpdate, opt => opt.MapFrom(src => src.Auditable.UpdatebyId))
    .ReverseMap()
    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => MappperNotNull.IsValidValue(srcMember)));
    }
}