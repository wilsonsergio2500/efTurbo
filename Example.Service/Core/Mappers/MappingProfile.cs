using AutoMapper;
using Example.Service.Core.Data.Entity;
using Example.Service.Core.DTOs;

namespace Example.Service.Core.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<PersonEntity, PersonDTO>().ReverseMap();
        }
    }
}
