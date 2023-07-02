using EF.Turbo.Repo.Core.Entity;

namespace Example.Repo.Core.Entity
{
    public class OrganizationEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TicketSymbol { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? UpdatedDate { get; set; } = null;
        public DateTime CreatedDate { get; set; }

    }
}
