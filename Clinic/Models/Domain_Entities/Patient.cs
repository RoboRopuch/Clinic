using Microsoft.AspNetCore.Identity;

namespace Clinic.Models.Domain_Entities
{
    public class Patient
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Navigation property to the associated user
        public IdentityUser User { get; set; }
        public ICollection<Visits>? Visits { get; set; }
    }
}
