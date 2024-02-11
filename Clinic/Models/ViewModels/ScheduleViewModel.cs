using Clinic.Models.Domain_Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Clinic.Models.ViewModels
{
    public class ScheduleViewModel
    {
        public IEnumerable<SelectListItem> Docs { get; set; }
        public Doctor Doctor { get; set; }
        public Guid DoctorId { get; set; }
        public string Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }        
    }

}

