using EF.Turbo.Service.Core.DTOs;

namespace Example.Service.Core.DTOs
{
    public class PersonDTO: BaseDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
