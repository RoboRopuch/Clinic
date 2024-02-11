using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class VisitsRepository : IVisitsRepository
    {
        private readonly AuthDbContext clinicDbContext;

        public VisitsRepository(AuthDbContext clinicDbContext)
        {
            this.clinicDbContext = clinicDbContext;
        }

        public async Task<Visits?> GetAsync(Guid id)
        {
            var visit = await clinicDbContext.Visits
                .FirstOrDefaultAsync(t => t.Id == id);
            return visit;
        }

        public async Task<Visits> AddAsync(Visits record)
        {

            await clinicDbContext.Visits.AddAsync(record);
            await clinicDbContext.SaveChangesAsync();

            return record;
        }

        public async Task<IEnumerable<Visits>> GetAllAsync()
        {
            var visits =await clinicDbContext.Visits.ToListAsync();
            return visits;
        }

        public async Task<IEnumerable<Visits>> GetAllBySpec(string Spec)
        {
            var visits = await clinicDbContext.Visits
                .Include(v => v.Doctor)
                .Where(v => v.Doctor.Specialisation == Spec && v.Isbooked == false)
                .OrderBy(v => v.StartTime)
                .ToListAsync();



            return visits;
        }


        public async Task<Visits?> UpdateAsync(Visits visit)
        {
            var existingVisit = await clinicDbContext.Visits.FindAsync(visit.Id);

            if (existingVisit != null)
            {
                // Copy values from the incoming visit to the existing entity
                clinicDbContext.Entry(existingVisit).CurrentValues.SetValues(visit);

                try
                {
                    // Save changes, including the incremented RowVersion
                    await clinicDbContext.SaveChangesAsync();
                    return existingVisit;
                }
                catch (DbUpdateConcurrencyException)
                {
                    // Handle concurrency exception if necessary
                    throw;
                }
            }

            return null;
        }


        private byte[] GenerateNewRowVersion()
        {
            // Generate a new RowVersion; this could be based on a timestamp or any other logic
            return Guid.NewGuid().ToByteArray();
        }

        public async Task<Visits> GetVisitWithPatient(Guid visitId)
        {
            var visit = await clinicDbContext.Visits
                .Include(v => v.Patient)
                .FirstOrDefaultAsync(v => v.Id == visitId);

            return visit;
        }

        public async Task<Visits> GetVisitWithDoctor(Guid visitId)
        {
            var visit = await clinicDbContext.Visits
                .Include(v => v.Doctor)
                .AsNoTracking()
                .FirstOrDefaultAsync(v => v.Id == visitId);

            return visit;
        }

    }
}
