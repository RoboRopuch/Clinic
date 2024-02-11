namespace Clinic.Models.Domain_Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public string FirstDayOfWeek { get; set; }
        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Day { get; set; }
        public  DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

    }
}
