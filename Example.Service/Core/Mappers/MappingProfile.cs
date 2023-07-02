using AutoMapper;
using Example.Repo.Core.Entity;
using Example.Service.Core.DTOs;

namespace Example.Service.Core.Mappers
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            CreateMap<PersonEntity, PersonDTO>().ReverseMap();
            CreateMap<OrganizationEntity, OrganizationDTO>().ReverseMap();
        }
    }
}
