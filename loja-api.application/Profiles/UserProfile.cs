using AutoMapper;
using loja_api.application.Mapper.User;
using loja_api.domain.Entities;

namespace loja_api.application.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {

        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<User, UserUpdateDTO>().ReverseMap();

        CreateMap<User, UserCreateDTO>().ReverseMap()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
    }
}
