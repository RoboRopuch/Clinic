using Clinic.Models.Domain_Entities;

namespace Clinic.Repositories
{
    public interface IVisitsRepository
    {

        Task<Visits> AddAsync(Visits record);

        Task<Visits> GetVisitWithPatient(Guid visitId);
        Task<Visits> GetVisitWithDoctor(Guid visitId);

        Task<IEnumerable<Visits>> GetAllAsync();
        Task<Visits?> UpdateAsync(Visits visit);

        Task<Visits?> GetAsync(Guid id);

        Task<IEnumerable<Visits>> GetAllBySpec(string Spec);


    }
}
