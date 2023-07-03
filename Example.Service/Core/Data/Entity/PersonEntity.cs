using EF.Turbo.Repo.Core.Entity;

namespace Example.Service.Core.Data.Entity
{
    public class PersonEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
