using Clinic.Models.Domain_Entities;

namespace Clinic.Models.ViewModels
{
    public class BookBySpecRequest
    {
        public IEnumerable<Visits> Visits { get; set; }
        public string Specialisation { get; set; }

    }
}
