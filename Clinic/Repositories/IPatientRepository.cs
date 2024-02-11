using Clinic.Models.Domain_Entities;

namespace Clinic.Repositories
{
    public interface IPatientRepository
    {
        Task <IEnumerable<Patient>> GetAllAsync();

        Task<Patient> AddAsync(Patient doc);

        Task<IEnumerable<Visits>> GetAppointments(Guid id);

        Task<IEnumerable<Visits>> GetFinishedAppointments(Guid id);
        Task<Patient?> DeleteAsync(Guid id);

        Task<Patient?> GetAsyncByUser(string Userid);

        Task<Patient?> UpdateAsync(Patient doc);
        Task<Patient?> GetAsync(Guid id);
    }
}
