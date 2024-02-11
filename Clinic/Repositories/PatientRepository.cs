using Azure;
using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Microsoft.EntityFrameworkCore;

namespace Clinic.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly AuthDbContext clinicDbContext;

        public PatientRepository(AuthDbContext clinicDbContext)
        {
            this.clinicDbContext = clinicDbContext;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var docs = await clinicDbContext.Patients.ToListAsync();
            
            return docs;
        }


        public async Task<Patient> AddAsync(Patient patient) {

            await clinicDbContext.Patients.AddAsync(patient);
            await clinicDbContext.SaveChangesAsync();

            return patient;
        }

        public async Task<Patient?> DeleteAsync(Guid id)
        {
            var existingDoc = await clinicDbContext.Patients.FindAsync(id);

            if (existingDoc != null)
            {
                clinicDbContext.Patients.Remove(existingDoc);
                await clinicDbContext.SaveChangesAsync();

                return existingDoc;
            }

            return null;
        }
        public async Task<Patient?> GetAsync(Guid id)
        {
            var doc = await clinicDbContext.Patients.FirstOrDefaultAsync(t => t.Id == id);
            return doc;
        }

        public async Task<Patient?> UpdateAsync(Patient doc)
        {
            var existingDoc = await clinicDbContext.Patients.FindAsync(doc.Id);

            if (existingDoc != null)
            {
                existingDoc.Name = doc.Name;
                existingDoc.Surname = doc.Surname;

                await clinicDbContext.SaveChangesAsync();

                return existingDoc;
            }

            return null;
        }

        public async Task<Patient?> GetAsyncByUser(string userId)
        {
            // Assuming your DbContext is named 'YourDbContext'
            var Patient = await clinicDbContext.Patients
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.UserId == userId);

            return Patient;
        }

        public async Task<IEnumerable<Visits>> GetAppointments(Guid id)
        {
            var visits = await clinicDbContext.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Where(v => v.PatientId == id)
                .ToListAsync();

            return visits;
        }

        public async Task<IEnumerable<Visits>> GetFinishedAppointments(Guid id)
        {
            var visits = await clinicDbContext.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Where(v => v.PatientId == id && v.IsFinished == true)
                .ToListAsync();

            return visits;
        }

    }
}

