using Clinic.Models.Domain_Entities;
using System.Globalization;

namespace Clinic.Models.ViewModels
{
    public class AddDoctorRequest
    {
        public string Name { get; set; }
        public  string Surname { get; set; }
        public string Specialisation { get; set; }
        public  string  Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
