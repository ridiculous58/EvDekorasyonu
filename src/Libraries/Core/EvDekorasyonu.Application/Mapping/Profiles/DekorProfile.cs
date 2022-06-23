using AutoMapper;
using EvDekorasyonu.Application.Features.Queries.ViewModels;
using EvDekorasyonu.Domain.Dtos;
using EvDekorasyonu.Domain.Entities;

namespace EvDekorasyonu.Application.Mapping.Profiles
{
    public class DekorProfile : Profile
    {
        public DekorProfile()
        {
            CreateMap<Dekor, DekorViewModel>()
                .ReverseMap();
            CreateMap<DekorCategory, DekorCategoryViewModel>()
                .ReverseMap();

            CreateMap<Dekor, DekorDto>()
                .ReverseMap();
        }
    }
}
