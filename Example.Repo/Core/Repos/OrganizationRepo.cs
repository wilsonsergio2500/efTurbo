using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Repo.Core.Repo;
using Example.Repo.Core.Entity;
using Example.Repo.Core.Specs;

namespace Example.Repo.Core.Repos
{
    public interface IOrganizationRepo: IBaseRepo<ExampleDbContext, OrganizationEntity>
    {
        Task<bool> AnyAsync(IOrganizationSpecification specification, CancellationToken cancellationToken = default);
    }
    public class OrganizationRepo : BaseRepo<ExampleDbContext, OrganizationEntity>, IOrganizationRepo
    {
        public OrganizationRepo(ExampleDbContext dbContext) : base(dbContext)
        {
        }

        public override Task<OrganizationEntity> AddAsync(OrganizationEntity entity, CancellationToken cancellationToken = default)
        {
            entity.CreatedDate = DateTime.UtcNow;
            return base.AddAsync(entity, cancellationToken);
        }

        public override Task DeleteAsync(OrganizationEntity entity, CancellationToken cancellationToken = default)
        {
            entity.Active = false;
            return base.UpdateAsync(entity, cancellationToken);
        }

        public override async Task<OrganizationEntity?> UpdateAsync(OrganizationEntity entity, CancellationToken cancellationToken = default)
        {
            entity.UpdatedDate = DateTime.UtcNow;
            return await base.UpdateAsync(entity, cancellationToken);
        }

        public override Task<List<OrganizationEntity>> ListAsync(CancellationToken cancellationToken = default)
        {
            return base.ListAsync(new OrganizationSpecification());
        }

        public override Task<int> CountAsync(CancellationToken cancellationToken = default)
        {
            return base.CountAsync(new OrganizationSpecification());
        }

        public Task<bool> AnyAsync(IOrganizationSpecification specification, CancellationToken cancellationToken = default)
        {
            return base.AnyAsync(specification, cancellationToken);
        }

    }
}
