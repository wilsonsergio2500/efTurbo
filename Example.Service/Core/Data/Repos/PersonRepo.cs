using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Repo.Core.Repo;
using Example.Service.Core.Data.Entity;

namespace Example.Service.Core.Data.Repos
{
    public class PersonRepo : BaseRepo<ExampleDbContext, PersonEntity>, IBaseRepo<ExampleDbContext, PersonEntity>
    {
        public PersonRepo(ExampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
