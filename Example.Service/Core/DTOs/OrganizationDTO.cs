using EF.Turbo.Service.Core.DTOs;

namespace Example.Service.Core.DTOs
{
    public class OrganizationDTO: BaseDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string TicketSymbol { get; set; }
        public bool Active { get; set; } = true;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

    }
}
