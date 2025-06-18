using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace WebApiReynoVerde
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<DTO.UserFormRegistrationDto, IdentityUser>()
                .ForMember(u => u.UserName, opt => opt.MapFrom(x => x.Email));
        }
    }
}
