using AutoMapper;
using EvDekorasyonu.Domain.Dtos;
using Microsoft.AspNetCore.Identity;

namespace EvDekorasyonu.Application.Mapping.Profiles
{
    public class RegisterProfile : Profile
    {
        public RegisterProfile()
        {
            CreateMap<IdentityUser, RegisterDto>()
                .ReverseMap();
        }
    }
}
