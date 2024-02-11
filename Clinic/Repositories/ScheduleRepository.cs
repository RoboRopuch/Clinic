using Azure;
using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly AuthDbContext clinicDbContext;

        public ScheduleRepository(AuthDbContext AuthDbContext)
        {
            this.clinicDbContext = AuthDbContext;
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            var scheduleRecord = await clinicDbContext.Schedule.ToListAsync();
            
            return scheduleRecord;
        }

        public async Task<IEnumerable<Schedule>> GetAllWithDocAsync()
        {
            var scheduleRecord = await clinicDbContext.Schedule
                .Include(s => s.Doctor)
                .ToListAsync(); 
            ;

            return scheduleRecord;
        }

        public async Task<Schedule> AddAsync(Schedule record)
        {
            // Log the SQL statement to check the generated SQL
            Console.WriteLine(clinicDbContext.Database.GenerateCreateScript());

            try
            {
                await clinicDbContext.Schedule.AddAsync(record);
                await clinicDbContext.SaveChangesAsync();

                return record;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding schedule: {ex.Message}");
                throw;
            }
        }


        public async Task<Schedule?> DeleteAsync(Guid id)
        {
            var existingRecord = await clinicDbContext.Schedule.FindAsync(id);

            if (existingRecord != null)
            {
                clinicDbContext.Schedule.Remove(existingRecord);
                await clinicDbContext.SaveChangesAsync();

                return existingRecord;
            }

            return null;
        }

        public async Task<Schedule?> DeleteAsyncWithUnfinishedVisits(Guid id)
        {
            // Find the schedule record
            var existingRecord = await clinicDbContext.Schedule
                .Include(s => s.Doctor) // Include related doctor
                .FirstOrDefaultAsync(s => s.Id == id);

            if (existingRecord != null)
            {
                // Check for unfinished visits associated with the doctor
                var unfinishedVisits = clinicDbContext.Visits
                    .Where(v => v.DoctorId == existingRecord.DoctorId && !v.IsFinished)
                    .ToList();

                // Remove the schedule and save changes
                clinicDbContext.Schedule.Remove(existingRecord);
                await clinicDbContext.SaveChangesAsync();


                if (unfinishedVisits.Any())
                {
                    foreach (var v in unfinishedVisits) { 
                    
                        clinicDbContext.Visits.Remove(v);
                        await clinicDbContext.SaveChangesAsync();
                    }
                    return null;
                }


                return existingRecord;
            }

            return null;
        }


    }
}

