using Azure;
using Clinic.Data;
using Clinic.Models.Domain_Entities;
using Clinic.Models.ViewModels;
using Clinic.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace Clinic.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IDocRepository docRepository;
        private readonly IVisitsRepository visitsRepository;
        private readonly UserManager<IdentityUser> userManager;

        public DoctorsController(IDocRepository docRepository, IVisitsRepository visitsRepository, UserManager<IdentityUser> userManager)
        {
            this.docRepository = docRepository;
            this.visitsRepository = visitsRepository;
            this.userManager = userManager;
        }


        [HttpGet]
        public async Task<IActionResult> List()
        {
            var docs = await docRepository.GetAllAsync();
            return View(docs);
        }

        [HttpGet]
        public IActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddDoctorRequest addDoctorRequest)
        {
            if (addDoctorRequest != null)
            {

                var doc = new Doctor
                {
                    //nie podajemy ID generuje sie samo
                    Name = addDoctorRequest.Name,
                    Surname = addDoctorRequest.Surname,
                    Specialisation = addDoctorRequest.Specialisation,
                };

                var identityUser = new IdentityUser
                {
                    UserName = addDoctorRequest.Username,
                    Email = addDoctorRequest.Email,
                };

                var identityResult = await userManager.CreateAsync(identityUser, addDoctorRequest.Password);
                //add connection frmom doctor to user id 
                if (identityResult.Succeeded)
                {
                    doc.User = identityUser;
                    doc.UserId = identityUser.Id;
                    var roleIdentityResult = await userManager.AddToRoleAsync(identityUser, "Doctor");


                    if (roleIdentityResult.Succeeded)
                    {

                        await docRepository.AddAsync(doc);
                        return RedirectToAction("List");
                    }

                }
            }
            //zwróc error że nie mogą byc te same nazwy użytkwoników
            return View("Error");

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Shifts()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var userId = user.Id;
                var shifts = await docRepository.GetShifts(userId);
                //var doc = bloggieDbContext.docs.Find(id);
                return View(shifts);
            }

            // Handle the case where the user is not found
            return NotFound(Shifts);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Appointments()
        {
            var user = await userManager.GetUserAsync(User);
            if (user != null)
            {
                var doctor = await docRepository.GetAsyncByUser(user.Id);
                var visits = await docRepository.GetAppointments(doctor.Id);
                //var doc = bloggieDbContext.docs.Find(id);
                return View(visits);
            }

            // Handle the case where the user is not found
            return NotFound(Shifts);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            //var doc = bloggieDbContext.docs.Find(id);

            var doc = await docRepository.GetAsync(id);
            if (doc != null)
            {
                var editdocRequest = new Doctor
                {
                    Id = doc.Id,
                    Name = doc.Name,
                    Surname = doc.Surname,

                };

                return View(editdocRequest);
            }

            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Doctor doctor)
        {

            //mapping view model to domain model
            var doc = new Doctor
            {
                Id = doctor.Id,
                Name = doctor.Name,
                Surname = doctor.Surname,
                Specialisation = doctor.Specialisation
            };

            var updateddoc = await docRepository.UpdateAsync(doc);

            if (updateddoc != null)
            {
                return RedirectToAction("List");
                //return RedirectToAction("Edit", new { editdocRequest.id});

            }

            return RedirectToAction("Edit", new { doctor.Id });
        }

        [Authorize]

        [HttpGet]
        public async Task<IActionResult> Finish(string id) {
            var visitId = Guid.Parse(id);

            var visitWithPatient = await visitsRepository.GetVisitWithPatient(visitId);

            var finishRequest = new FinishVisitRequest
            {
                Day = visitWithPatient.Day,
                StartTime = visitWithPatient.StartTime,
                EndTime = visitWithPatient.EndTime,
                Patient = visitWithPatient.Patient,
                VisitId = visitId
            };

            return View(finishRequest);
        
        
        }


        [HttpPost]
        public async Task<IActionResult> Finish(FinishVisitRequest finishVisitRequest)
        {
            var visitId = finishVisitRequest.VisitId;
            var chosenVisit = await visitsRepository.GetAsync(visitId);
            var user = await userManager.GetUserAsync(User);

            var resignedVisit = new Visits
            {
                Id = visitId,
                FirstDayOfWeek = chosenVisit.FirstDayOfWeek,
                DoctorId = chosenVisit.DoctorId,
                PatientId = chosenVisit.PatientId,
                Patient = chosenVisit.Patient,
                Day = chosenVisit.Day,
                StartTime = chosenVisit.StartTime,
                EndTime = chosenVisit.EndTime,
                Isbooked = chosenVisit.Isbooked,
                IsFinished = true,
                Description = finishVisitRequest.Descripton

            };

            await visitsRepository.UpdateAsync(resignedVisit);

            return RedirectToAction("Appointments");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Guid Id)
        {
            var doc = await docRepository.GetAsync(Id);
            var userId = doc.UserId.ToString();



            var user = await userManager.FindByIdAsync(userId);
            var result = await userManager.DeleteAsync(user);

            await docRepository.DeleteAsync(Id);
            return RedirectToAction("List");
        }

        [HttpGet]
        public async Task<IActionResult> Raport()
        {
            var raportRequest = new RaportRequest
            {
                StartDay = DateTime.Now,
                EndDay = DateTime.Now,
            };

            return View(raportRequest);
        }


        public async Task<IActionResult> Raport(RaportRequest raportRequest) { 

            var allDocs = await docRepository.GetAllAsync();
            var details = new List<RaportRequestDetails>();

            foreach (var doc in allDocs)
            {
                var temp = new RaportRequestDetails();
                temp.doctorName = doc.Name;
                var shiftsForDoc = await docRepository.GetShiftsWithinTime(raportRequest.StartDay, raportRequest.EndDay, doc.Id);
                var timeSlots = new List<DayTimeSlot>();
                temp.visits = 0;
                foreach (var shift in shiftsForDoc) {

                    var tempTimeSlot = new DayTimeSlot
                    {
                        Day = shift.Day,
                        Start = shift.StartTime,
                        End = shift.EndTime
                    };
                    var visitsInShift = await docRepository.GetFinishedAppointmentsWithinTime(doc.Id, shift.StartTime, shift.EndTime, shift.Day);
                    var visitsNumber = visitsInShift.Count();
                    temp.visits += visitsNumber;
                    timeSlots.Add(tempTimeSlot);
                }

                temp.dayTimeSlots = timeSlots;

                details.Add(temp);

            }


            return View("RaportDetails", details);

        }


    }
}
