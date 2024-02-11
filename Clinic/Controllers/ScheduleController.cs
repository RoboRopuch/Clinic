using Clinic.Models.Domain_Entities;
using Clinic.Models.ViewModels;
using Clinic.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Numerics;

namespace Clinic.Controllers
{
    public class ScheduleController : Controller
    {

        private readonly IDocRepository docRepository;

        private readonly IScheduleRepository ScheduleRepository;

        private readonly IVisitsRepository visitsRpository;

        public ScheduleController(IDocRepository docRepository, IScheduleRepository scheduleRepository, IVisitsRepository visitsRepository)
        {
            this.docRepository = docRepository;
            this.ScheduleRepository = scheduleRepository;
            this.visitsRpository = visitsRepository;
        }


        [HttpGet]
        public  async Task<IActionResult> GraphicalSchedule()
        {
            var docs = await docRepository.GetAllAsync();
            return View(docs);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(Guid Id)
        {
            await ScheduleRepository.DeleteAsyncWithUnfinishedVisits(Id);

            return RedirectToAction("List");
        }


        [HttpGet]
        public async Task<IActionResult> List(DisplayScheduleRequest displayScheduleRequest)
        {
            var allShiftsTask = ScheduleRepository.GetAllWithDocAsync();

            var allShifts = await allShiftsTask;

            var displayInfo = new List<DisplayScheduleRequest>();

            foreach (var shift in allShifts)
            {

                displayInfo.Add(new DisplayScheduleRequest
                {
                    ShiftId = shift.Id,
                    Name = shift.Doctor?.Name,
                    Surname = shift.Doctor?.Surname,
                    Day = shift.Day,
                    StartTime = shift.StartTime,
                    EndTime = shift.EndTime,
                });
            }

            return View(displayInfo);
        }



        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //dodać ograniczenie,że można dodac rekord, w którym czas jest wielokrotnościa 15minut
            var docs = await docRepository.GetAllAsync();

            var viewModel = new ScheduleViewModel
            {
                Docs = docs.Select( x => new SelectListItem { Text = x.Name, Value = x.Id.ToString()  } ),

            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(ScheduleViewModel viewModel)
        {

            //wychwytywanie błędów
            var doctor = await docRepository.GetAsync(viewModel.DoctorId);


            var schedulerecord = new Schedule
            
            {
                //Doctor = doctor,
                DoctorId =  viewModel.DoctorId,
                FirstDayOfWeek = "Monday",
                Day  = DateTime.Parse(viewModel.Day),
                StartTime = viewModel.StartTime,
                EndTime = viewModel.EndTime

            };

            DateTime temp = schedulerecord.StartTime;

            while (temp < schedulerecord.EndTime)
            {
                var visitsRecord = new Visits
                {
                    FirstDayOfWeek = "Monday",
                    StartTime = temp,
                    EndTime = temp.AddMinutes(15),
                    Isbooked = false,
                    IsFinished = false,
                    Day = DateTime.Parse(viewModel.Day),
                    Doctor = doctor,
                    DoctorId = viewModel.DoctorId,
                    RowVersion = Guid.NewGuid().ToByteArray()
            };

                Console.WriteLine("created");

                temp = temp.AddMinutes(15);

                await visitsRpository.AddAsync(visitsRecord);


            }


            await ScheduleRepository.AddAsync(schedulerecord);

            return RedirectToAction("List");
            }





    }
}

//| Lekarz | Czas z grafiku                  | Liczba wizyt |
//|---------------|---------------------------------|--------------|
//| Dr. Smith     | Poniedziałek: 8:00 - 16:00 | 20 |
//|               | Wtorek: 8:00 - 16:00 |              |
//|               | Środa: 8:00 - 12:00 |              |
//| ...           | ...                             | ...          |
//| Dr.Johnson | Poniedziałek: 9:00 - 17:00 | 15 |
//|               | Wtorek: 9:00 - 17:00 |              |
//| ...           | ...                             | ...          |

