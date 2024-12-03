using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;
using mymvc.Models.ViewModels;
using mymvc.Utility;
using System.Security.Cryptography;

namespace mymvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class MonitorController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MonitorController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            MonitorIndexVM objMonitorIndexList = new();
            objMonitorIndexList.ListCount = 0;
            List<Models.Monitor> objMonitorList = _UnitOfWork.Monitor.GetAll().ToList();
            /*List<Lecturer> objLecturerList = _UnitOfWork.Lecturer.GetAll().ToList();
            List<Course> objCourseList = _UnitOfWork.Course.GetAll().ToList();

            foreach (Models.Monitor MonitorEntry in objMonitorList)
                foreach (Lecturer LecturerEntry in objLecturerList)
                    if (LecturerEntry.LID == MonitorEntry.LID)
                        foreach(Course CourseEntry in objCourseList)
                            if (CourseEntry.CourseId == MonitorEntry.CourseId)
                            {
                                objMonitorIndexList.Course.Add(CourseEntry);
                                objMonitorIndexList.Lecturer.Add(LecturerEntry);
                                objMonitorIndexList.ListCount++;
                            }*/

            return View(objMonitorList);
        }
        public IActionResult UpsertLecturer(int? id, int? id2)
        {
            MonitorLecturerVM MonitorLecturerVM = new()
            {
                LecturerList = _UnitOfWork.Lecturer.GetAll().Select(u => new SelectListItem
                {
                    Text = u.FULL_NAME,
                    Value = u.LID.ToString()
                }),
                Lecturer = new Lecturer()
            };
            if (id == null || id == 0 || id2 == null || id2 == 0) return View(MonitorLecturerVM); //create
            else
            {
                //update
                MonitorLecturerVM.Lecturer = _UnitOfWork.Lecturer.Get(u => u.LID == id);
                MonitorLecturerVM.CourseID = id2;

                return View(MonitorLecturerVM);
            }
        }
        public IActionResult UpsertCourse(MonitorLecturerVM MonitorLecturerVM)
        {
            MonitorLecturerVM.Lecturer = _UnitOfWork.Lecturer.Get(u => u.LID == MonitorLecturerVM.Lecturer.LID);


            MonitorCourseVM MonitorCourseVM = new()
            {
                CourseList = _UnitOfWork.Course.GetAll().Where(u => u.Department == MonitorLecturerVM.Lecturer.DEPARTMENT).Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                }),
                Course = new Course(),
                IsCreate = MonitorLecturerVM.CourseID !=0 && MonitorLecturerVM.CourseID != null ? false : true,
                LID = MonitorLecturerVM.Lecturer.LID
            };
            if (MonitorCourseVM.IsCreate) return View(MonitorCourseVM); //create
            else
            {
                //update
                MonitorCourseVM.Monitor = _UnitOfWork.Monitor.Get(u => u.LID == MonitorLecturerVM.Lecturer.LID && u.CourseId==MonitorLecturerVM.CourseID);

                return View(MonitorCourseVM);
            }
        }
        /*[HttpPost]*/
        public IActionResult UpsertCourse1(MonitorCourseVM MonitorCourseVM)
        {
            /*            MonitorCourseVM.Monitor.Course = _UnitOfWork.Course.Get(u => u.CourseId == MonitorCourseVM.Monitor.CourseId);
                        MonitorCourseVM.Monitor.Lecturer = _UnitOfWork.Lecturer.Get(u => u.LID == MonitorCourseVM.Monitor.LID);*/
            Models.Monitor existing = _UnitOfWork.Monitor.Get(u => u.LID == MonitorCourseVM.Monitor.LID && u.CourseId == MonitorCourseVM.Monitor.CourseId);
            if (existing==null)
            {
                if (MonitorCourseVM.IsCreate)
                {
                    _UnitOfWork.Monitor.Add(MonitorCourseVM.Monitor);
                    TempData["success"] = "Schedule created successfully!!!";
                }
                else
                {
                    _UnitOfWork.Monitor.update(MonitorCourseVM.Monitor);
                    TempData["success"] = "Schedule updated successfully!!!";
                }
                _UnitOfWork.Save();
            }
            return RedirectToAction("Index");
        }
        /*public IActionResult UpsertLecturer1(int id, int id2)
        {
            return RedirectToAction("UpsertCourse", new { LID = id , CourseID = id2 } );
        }*/

        #region API CALLS
        /*[HttpGet]
        public IActionResult GetAll()
        {
            List<Models.Monitor> objMonitorList = _UnitOfWork.Monitor.GetAll().ToList();
            return Json(new { data = objMonitorList });
        }*/

        /*[HttpDelete]*/
        public IActionResult Delete(int? id, int? id2)
        {
            var MonitorToBeDeleted = _UnitOfWork.Monitor.Get(u => u.LID == id && u.CourseId== id2);
            if (MonitorToBeDeleted == null)
            {
                return RedirectToAction("Index");/*Json(new { success = false, message = "Error while deleting" });*/
            }

            _UnitOfWork.Monitor.Remove(MonitorToBeDeleted);
            _UnitOfWork.Save();
            return RedirectToAction("Index");/*Json(new { success = true, message = "Delete Successful" });*/
        }

        #endregion
    }
}