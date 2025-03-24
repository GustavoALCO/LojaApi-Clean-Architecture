using AutoMapper;
using loja_api.application.Mapper.Storage;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Profiles;

public class StorageProfile : Profile
{
    public StorageProfile()
    {

        CreateMap<Storage, StorageDTO>().ReverseMap();

        CreateMap<Storage, StorageCreateDTO>()
                    // Mapeia as propriedades de "Auditable" diretamente para "StorageDTO" 
                    .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => src.Auditable.CreateDate))
                    .ForMember(dest => dest.CreatebyId, opt => opt.MapFrom(src => src.Auditable.CreatebyId))
                    .ReverseMap()
                    //recria um objeto "Auditable"
                    .ForMember(dest => dest.Auditable, opt => opt.MapFrom(src => new Auditable
                    {
                        CreateDate = src.CreateDate,
                        CreatebyId = src.CreatebyId,
                    }));

        CreateMap<Storage, StorageUpdateDTO>()
            .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.Auditable.UpdateDate))
            .ForMember(dest => dest.UpdatebyId, opt => opt.MapFrom(src => src.Auditable.UpdatebyId))
            // Ignora valores nulos
            .ReverseMap() // Primeiro chamamos o ReverseMap()
            .ForMember(dest => dest.Auditable, opt => opt.MapFrom(src => new Auditable
            {
                UpdateDate = src.UpdateDate,
                UpdatebyId = src.UpdatebyId
            }))
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

    }
}