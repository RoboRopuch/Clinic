using Azure;
using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Clinic.Repositories
{
    public class DocRepository : IDocRepository
    {
        private readonly AuthDbContext clinicDbContext;

        public DocRepository(AuthDbContext clinicDbContext)
        {
            this.clinicDbContext = clinicDbContext;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            var docs = await clinicDbContext.Doctors.ToListAsync();
            
            return docs;
        }

        public async Task<IEnumerable<Schedule>> GetShifts(string id)
        {
            var shifts = await clinicDbContext.Doctors
                .Where(d => d.UserId == id)
                .SelectMany(d => d.Shifts)
                .ToListAsync();


            return shifts; 
        }

        public async Task<IEnumerable<Schedule>> GetShiftsWithinTime(DateTime start, DateTime end, Guid docId)
        {
            var shifts = await clinicDbContext.Schedule
                .Where(s => s.Day >= start && s.Day <= end && s.Doctor.Id == docId)
                .ToListAsync();

            return shifts;
        }


        public async Task<Doctor> AddAsync(Doctor doc) {

            await clinicDbContext.Doctors.AddAsync(doc);
            await clinicDbContext.SaveChangesAsync();

            return doc;
        }



        public async Task<Doctor?> DeleteAsync(Guid id)
        {
            var existingDoc = await clinicDbContext.Doctors.FindAsync(id);

            if (existingDoc != null)
            {
                clinicDbContext.Doctors.Remove(existingDoc);
                await clinicDbContext.SaveChangesAsync();

                return existingDoc;
            }

            return null;
        }
        public async Task<Doctor?> GetAsync(Guid id)
        {
            var doc = await clinicDbContext.Doctors.FirstOrDefaultAsync(t => t.Id == id);
            return doc;
        }

        public async Task<IEnumerable<Visits>> GetAppointments(Guid id)
        {
            var visits = await clinicDbContext.Visits
                .Include(v => v.Doctor)
                .Include(v => v.Patient)
                .Where(v => v.DoctorId == id && v.Isbooked == true)
                .ToListAsync();

            return visits;
        }

        public async Task<Doctor?> UpdateAsync(Doctor doc)
        {
            var existingDoc = await clinicDbContext.Doctors.FindAsync(doc.Id);

            if (existingDoc != null)
            {
                existingDoc.Name = doc.Name;
                existingDoc.Surname = doc.Surname;
                existingDoc.Specialisation = doc.Specialisation;

                await clinicDbContext.SaveChangesAsync();

                return existingDoc;
            }

            return null;
        }

        public async Task<Doctor?> GetAsyncByUser(string userId)
        {
            // Assuming your DbContext is named 'YourDbContext'
            var doctor = await clinicDbContext.Doctors
                .Include(d => d.User)
                .FirstOrDefaultAsync(d => d.UserId == userId);

            return doctor;
        }

        public async Task<IEnumerable<Visits>> GetFinishedAppointmentsWithinTime(Guid doctorId, DateTime startTime, DateTime endTime, DateTime day)
        {
            var finishedAppointments = await clinicDbContext.Visits
                .Where(v => v.DoctorId == doctorId && v.IsFinished == true && v.Day == day)
                .Where(v => v.StartTime >= startTime && v.EndTime <= endTime)
                .ToListAsync();

            return finishedAppointments;
        }

    }
}

