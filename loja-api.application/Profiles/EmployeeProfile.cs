using AutoMapper;
using loja_api.application.Mapper.Employee;
using loja_api.domain.Entities;
using loja_api.domain.Entities.auxiliar;

namespace loja_api.application.Profiles;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employee, EmployeeDTO>().ReverseMap();

        CreateMap<Employee, EmployeeCreateDTO>()
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

        CreateMap<Employee, EmployeeUpdateDTO>()
                    // Mapeia as propriedades de "Auditable" diretamente para "StorageDTO" 
                    .ForMember(dest => dest.UpdateDate, opt => opt.MapFrom(src => src.Auditable.UpdateDate))
                    .ForMember(dest => dest.UpdatebyId, opt => opt.MapFrom(src => src.Auditable.UpdatebyId))
                    .ReverseMap()
                    //recria um objeto "Auditable"
                    .ForMember(dest => dest.Auditable, opt => opt.MapFrom(src => new Auditable
                    {
                        UpdateDate = src.UpdateDate,
                        UpdatebyId = src.UpdatebyId,
                    })).ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}