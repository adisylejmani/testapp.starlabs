using AutoMapper;
using Test.DTOS;
using Test.Models;

namespace Test.Profiles
{
    public class PersonProfiles : Profile
    {
        public PersonProfiles()
        {
            CreateMap<CreatePersonRequest, Person>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(dest => dest.LastName))
                .ReverseMap();

            CreateMap<CreatePersonResponse, Person>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(dest => dest.LastName))
                .ReverseMap();

            CreateMap<CreatePersonResponse, CreatePersonRequest>()
                .ForMember(dest => dest.FirstName, act => act.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.LastName, act => act.MapFrom(dest => dest.LastName))
                .ReverseMap();
        }
    }
}
