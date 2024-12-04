using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;
using mymvc.Models.ViewModels;
using mymvc.Utility;

namespace mymvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class CreateScheduleController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateScheduleController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            List<CreateSchedule> objCreateScheduleList = _UnitOfWork.CreateSchedule.GetAll().ToList();
            foreach (CreateSchedule createSchedule in objCreateScheduleList)
            {
                createSchedule.Schedule = _UnitOfWork.Schedule.Get(u => u.ScheduleId == createSchedule.ScheduleID);
                createSchedule.Student = _UnitOfWork.Student.Get(u => u.Mssv == createSchedule.Mssv);
            }

            return View(objCreateScheduleList);
        }

        public IActionResult UpsertStudent(int? id, int? id2)
        {
            CreateScheduleStudentVM createScheduleStudentVM = new()
            {
                StudentList = _UnitOfWork.Student.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Mssv.ToString()
                }),
                Student = new Student()
            };

            if (id == null || id == 0 || id2 == null || id2 == 0)
            {
                return View(createScheduleStudentVM); // Create
            }
            else
            {
                // Update
                createScheduleStudentVM.Student = _UnitOfWork.Student.Get(u => u.Mssv == id);
                createScheduleStudentVM.ScheduleID = id2;

                return View(createScheduleStudentVM);
            }
        }

        public IActionResult UpsertSchedule(CreateScheduleStudentVM createScheduleStudentVM)
        {
            createScheduleStudentVM.Student = _UnitOfWork.Student.Get(u => u.Mssv == createScheduleStudentVM.Student.Mssv);

            CreateScheduleScheduleVM createScheduleScheduleVM = new()
            {
                //ScheduleList = _UnitOfWork.Schedule.GetAll()
                    //.Where(u => u.Location == createScheduleStudentVM.Student.Name)
                    //.Select(u => new SelectListItem
                    //{
                    //    Text = u.ScheduleName,
                    //    Value = u.ScheduleID.ToString()
                    //}),
                Schedule = new Schedule(),
                Mssv = createScheduleStudentVM.Student.Mssv
            };

            {
                return View(createScheduleScheduleVM); // Create
            }
           
        }

        public IActionResult Delete(int? id, int? id2)
        {
            if (id == null || id2 == null) return NotFound();

            CreateSchedule createSchedule = _UnitOfWork.CreateSchedule.Get(u => u.Mssv == id && u.ScheduleID == id2);

            if (createSchedule == null) return NotFound();

            createSchedule.Schedule = _UnitOfWork.Schedule.Get(u => u.ScheduleId == createSchedule.ScheduleID);
            createSchedule.Student = _UnitOfWork.Student.Get(u => u.Mssv == createSchedule.Mssv);

            return View(createSchedule);
        }

        /*[HttpPost]*/
        //public IActionResult UpsertSchedule1(CreateScheduleScheduleVM createScheduleScheduleVM)
        //{
        //    CreateSchedule existing = _UnitOfWork.CreateSchedule.Get(u =>
        //        u.Mssv == createScheduleScheduleVM.Mssv &&
        //        u.ScheduleID == createScheduleScheduleVM.CreateSchedule.ScheduleID);

        //    if (existing == null)
        //    {
        //        if (createScheduleScheduleVM.IsCreate)
        //        {
        //            _UnitOfWork.CreateSchedule.Add(createScheduleScheduleVM.CreateSchedule);
        //            TempData["success"] = "CreateSchedule created successfully!!!";
        //        }
        //        else
        //        {
        //            _UnitOfWork.CreateSchedule.Update(createScheduleScheduleVM.CreateSchedule);
        //            TempData["success"] = "CreateSchedule updated successfully!!!";
        //        }

        //        _UnitOfWork.Save();
        //    }
        //    else
        //    {
        //        TempData["error"] = "CreateSchedule already exists";
        //    }

        //    return RedirectToAction("Index");
        //}

        #region API CALLS

        public IActionResult Delete1(int? id, int? id2)
        {
            var createScheduleToBeDeleted = _UnitOfWork.CreateSchedule.Get(u => u.Mssv == id && u.ScheduleID == id2);
            if (createScheduleToBeDeleted == null)
            {
                return RedirectToAction("Index");
            }

            _UnitOfWork.CreateSchedule.Remove(createScheduleToBeDeleted);
            _UnitOfWork.Save();
            TempData["success"] = "CreateSchedule deleted successfully!!!";
            return RedirectToAction("Index");
        }

        #endregion
    }
}
