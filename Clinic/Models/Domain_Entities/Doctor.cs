using Microsoft.AspNetCore.Identity;

namespace Clinic.Models.Domain_Entities

{
    public class Doctor
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Specialisation { get; set; }

        // Navigation property to the associated user
        public IdentityUser User { get; set; }


        public ICollection<Schedule>? Shifts { get; set; }
        public ICollection<Visits>? Visits { get; set; }
    }
}
