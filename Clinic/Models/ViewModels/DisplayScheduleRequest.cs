using Clinic.Models.Domain_Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Models.ViewModels
{
    public class DisplayScheduleRequest
    {
        public Guid ShiftId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
