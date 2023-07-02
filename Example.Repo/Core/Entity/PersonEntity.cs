using EF.Turbo.Repo.Core.Entity;

namespace Example.Repo.Core.Entity
{
    public class PersonEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

    }
}
