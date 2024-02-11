using Clinic.Models.Domain_Entities;

namespace Clinic.Models.ViewModels
{
    public class FinishVisitRequest
    {
        public string? Descripton { get; set; }
        public Guid VisitId { get; set; }
        public DateTime Day { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Patient Patient { get; set; }

    }
}
