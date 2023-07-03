using Ardalis.Specification;
using Example.Service.Core.Data.Entity;

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
