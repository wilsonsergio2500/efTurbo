using Ardalis.Specification;
using Example.Repo.Core.Entity;

namespace Example.Repo.Core.Specs
{
    public interface IOrganizationSpecification: ISpecification<OrganizationEntity>
    {

    }
    public class OrganizationSpecification: Specification<OrganizationEntity>, IOrganizationSpecification
    {
        public OrganizationSpecification() 
        {
            Query.Where(x => x.Active == true);
        }
    }
}
