using Azure;
using Clinic.Models.Domain_Entities;

namespace Clinic.Repositories
{
    public interface IDocRepository
    {
        Task <IEnumerable<Doctor>> GetAllAsync();

        Task<Doctor> AddAsync(Doctor doc);

        Task<Doctor?> DeleteAsync(Guid id);

        Task<Doctor?> GetAsyncByUser(string Userid);

        Task<IEnumerable<Visits>> GetAppointments(Guid id);

        Task<Doctor?> UpdateAsync(Doctor doc);
        Task<IEnumerable<Schedule>> GetShifts(string id);

        Task<IEnumerable<Visits>> GetFinishedAppointmentsWithinTime(Guid doctorId, DateTime startTime, DateTime endTime, DateTime day);

        Task<IEnumerable<Schedule>> GetShiftsWithinTime(DateTime start, DateTime end, Guid docId);

        Task<Doctor?> GetAsync(Guid id);
    }
}
