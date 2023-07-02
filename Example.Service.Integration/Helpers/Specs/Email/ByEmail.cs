using Ardalis.Specification;
using Example.Repo.Core.Entity;

namespace Example.Service.Integration.Helpers.Specs.Email
{
    public class ByEmail: Specification<PersonEntity>
    {
        public ByEmail(string email)
        {
            Query.Where(x => x.Email == email);
        }
    }
}
