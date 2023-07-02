using Ardalis.Specification;
using Example.Repo.Core.Entity;

namespace Example.Repo.Integration.Helpers.Specs.Person
{
    public class ById: Specification<PersonEntity>
    {
        public ById(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
