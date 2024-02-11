

using System.ComponentModel.DataAnnotations;

namespace Clinic.Models.Domain_Entities
{
    public class Visits
    {

    public Guid Id { get; set; }
    public string FirstDayOfWeek { get; set; }
    public Guid DoctorId { get; set; }
    public Doctor Doctor { get; set; }
    public Guid? PatientId { get; set; }
    public Patient? Patient{ get; set; }
    public DateTime Day { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }   
    public Boolean Isbooked { get; set; }
    public Boolean IsFinished { get; set; }
    public string? Description { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }


    }
}
