using AutoMapper;
using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Service.Core.Interfaces;
using EF.Turbo.Service.Core.Service;
using Example.Repo.Core;
using Example.Repo.Core.Entity;
using Example.Service.Core.DTOs;

namespace Example.Service.Core.Services
{
    public class PersonService : BaseService<ExampleDbContext, PersonEntity, PersonDTO>, IBaseService<ExampleDbContext, PersonEntity, PersonDTO>
    {
        public PersonService(IBaseRepo<ExampleDbContext, PersonEntity> baseRepo, IMapper autoMapper) : base(baseRepo, autoMapper)
        {
        }
    }
}
