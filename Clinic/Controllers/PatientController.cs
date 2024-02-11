using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Clinic.Models.ViewModels;
using Clinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Clinic.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository patientRepository;
        private readonly IVisitsRepository visitsRepository;
        private readonly AuthDbContext authDbContext;
        private readonly UserManager<IdentityUser> userManager;
        public PatientController(IPatientRepository patientRepository, IVisitsRepository visitsRepository, UserManager<IdentityUser> userManager, AuthDbContext authDbContext)
        {
            this.patientRepository = patientRepository;
            this.visitsRepository = visitsRepository;
            this.authDbContext = authDbContext;
            this.userManager = userManager;
        }

        [Authorize]
        public async Task<IActionResult> GetAppointments()
        {
            var user = await userManager.GetUserAsync(User);
            var patient = await patientRepository.GetAsyncByUser(user.Id);
            var visits = await patientRepository.GetAppointments(patient.Id);

            return View("Appointments", visits);
        }


        [Authorize]
        [HttpGet]
        public async Task<IActionResult> pickSpec()
        {
            return View("pickSpec");
        }

        [HttpPost]
        public async Task<IActionResult> pickSpec(PassSpec spec)
        {
            var visits = await visitsRepository.GetAllBySpec(spec.Specialisation);
            var listBySpec = new BookBySpecRequest { 
                Specialisation = spec.Specialisation,
                Visits = visits

            };


            return View("List", listBySpec);
        }

        [HttpGet]
        public async Task<IActionResult> ListSpec(string specialisation)
        {
            var visits = await visitsRepository.GetAllBySpec(specialisation);
            var listBySpec = new BookBySpecRequest
            {
                Specialisation = specialisation,
                Visits = visits

            };

            return View("List", listBySpec);
        }

        [HttpGet]
        public async Task<IActionResult> Book(string id)
        {
            var visitId = Guid.Parse(id);
            var chosenVisit = await visitsRepository.GetVisitWithDoctor(visitId);

            return View(chosenVisit);
        }

        [HttpPost]
        public async Task<IActionResult> Book(string id, byte[] rowVersion)
        {


            if (id == null)
            {
                return NotFound();
            }
            
            var visitId = Guid.Parse(id);
            var visit = await authDbContext.Visits
                .Include(v => v.Patient)
                .Include(v => v.Doctor)
                .FirstOrDefaultAsync(v => v.Id == visitId);


            if (visit == null)
            {
                Visits deletedVisit = new Visits();
                ModelState.AddModelError(string.Empty,
                    "visit has been cancelled.");
                ViewBag.Error = "Error";
                return View(deletedVisit);
            }

            var user = await userManager.GetUserAsync(User);
            var patient = await patientRepository.GetAsyncByUser(user.Id);

            if (patient == null)
            {
                return NotFound();
            }

            authDbContext.Entry(visit).Property("RowVersion").OriginalValue = rowVersion;
            

            try
            {
                visit.Patient = patient;
                visit.Isbooked = true;
                await authDbContext.SaveChangesAsync();
                return RedirectToAction("GetAppointments");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                var exceptionEntry = ex.Entries.Single();
                var databaseEntry = exceptionEntry.GetDatabaseValues();

                if (databaseEntry == null)
                {
                    Visits deletedVisit = new Visits();
                    ModelState.AddModelError(string.Empty, "The visit for this doctor has been cancelled");
                    ViewBag.Error = "Error";
                    return View(deletedVisit);
                }
                else
                {
                    ViewBag.Error = "Error";
                    var databaseValues = (Visits)databaseEntry.ToObject();
                    ModelState.AddModelError(string.Empty, "It appears that another user has already booked this appointment");
                    visit.RowVersion = (byte[])databaseValues.RowVersion;
                    ModelState.Remove("RowVersion");
                }
            }
            return View(visit);
        }


        public async Task<IActionResult> Resign(string id)
        {
            var visitId = Guid.Parse(id);
            var chosenVisit = await visitsRepository.GetAsync(visitId);
            var user = await userManager.GetUserAsync(User);
            var patient = await patientRepository.GetAsyncByUser(user.Id);

            var resignedVisit = new Visits
            {
                Id = visitId,
                FirstDayOfWeek = chosenVisit.FirstDayOfWeek,
                DoctorId = chosenVisit.DoctorId,
                PatientId = null,
                Patient = null,
                Day = chosenVisit.Day,
                StartTime = chosenVisit.StartTime,
                EndTime = chosenVisit.EndTime,
                Isbooked = false,
                IsFinished = chosenVisit.IsFinished,
                RowVersion = chosenVisit.RowVersion,
                
            };

            await visitsRepository.UpdateAsync(resignedVisit);

            return RedirectToAction("GetAppointments");
        }

        public async Task<IActionResult> ResignDetails(string id)
        {
            var visitId = Guid.Parse(id);
            var chosenVisit = await visitsRepository.GetVisitWithDoctor(visitId);

            return View(chosenVisit);
        }



        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details() {

            var user = await userManager.GetUserAsync(User);
            var patient = await patientRepository.GetAsyncByUser(user.Id);
            var finishedVisits = await patientRepository.GetFinishedAppointments(patient.Id);

            return View(finishedVisits);


        }



    }
}
