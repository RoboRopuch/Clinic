using Azure;
using Clinic.Models.Domain_Entities;

namespace Clinic.Repositories
{
    public interface IScheduleRepository
    {
        Task<IEnumerable<Schedule>> GetAllAsync();

        Task<IEnumerable<Schedule>> GetAllWithDocAsync();


        Task<Schedule> AddAsync(Schedule record);

        Task<Schedule?> DeleteAsync(Guid id);



        Task<Schedule?> DeleteAsyncWithUnfinishedVisits(Guid id);
    }
}
