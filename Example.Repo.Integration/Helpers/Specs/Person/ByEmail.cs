using Ardalis.Specification;
using Example.Repo.Core.Entity;

namespace Example.Repo.Integration.Helpers.Specs.Person
{
    public class ByEmail: Specification<PersonEntity>
    {
        public ByEmail(string email)
        {
            Query.Where(x => x.Email == email);
        }
    }
}
