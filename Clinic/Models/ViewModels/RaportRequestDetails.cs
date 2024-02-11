namespace Clinic.Models.ViewModels
{
    public class RaportRequestDetails
    {
        public string doctorName { get; set; }
        public IEnumerable<DayTimeSlot> dayTimeSlots { get; set; }

        public int visits { get; set; }

    }

    public class DayTimeSlot {
        public DateTime Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }

}
