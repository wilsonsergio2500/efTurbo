using AutoMapper;
using EF.Turbo.Service.Core.Interfaces;
using EF.Turbo.Service.Core.Service;
using Example.Repo.Core;
using Example.Repo.Core.Entity;
using Example.Repo.Core.Repos;
using Example.Repo.Core.Specs;
using Example.Service.Core.DTOs;

namespace Example.Service.Core.Services
{
    public interface IOrganizationService: IBaseService<ExampleDbContext, OrganizationEntity, OrganizationDTO>
    {
        Task<bool> AnyAsync(IOrganizationSpecification specification, CancellationToken cancellationToken = default);
    }
    public class OrganizationService : BaseService<ExampleDbContext, OrganizationEntity, OrganizationDTO>, IOrganizationService
    {
        public OrganizationService(IOrganizationRepo baseRepo, IMapper autoMapper) 
            : base(baseRepo, autoMapper)
        {
        }

        public Task<bool> AnyAsync(IOrganizationSpecification specification, CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(specification, cancellationToken);
        }

    }
}
