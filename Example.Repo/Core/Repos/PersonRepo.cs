using EF.Turbo.Repo.Core.Interfaces;
using EF.Turbo.Repo.Core.Repo;
using Example.Repo.Core.Entity;

namespace Example.Repo.Core.Repos
{
    public class PersonRepo : BaseRepo<ExampleDbContext, PersonEntity>, IBaseRepo<ExampleDbContext, PersonEntity>
    {
        public PersonRepo(ExampleDbContext dbContext) : base(dbContext)
        {
        }
    }
}
