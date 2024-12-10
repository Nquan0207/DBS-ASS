using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using mymvc.DataAccess.Data;
using mymvc.DataAccess.Repository;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;
using mymvc.Models.ViewModels;
using mymvc.Utility;

namespace mymvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Student)]
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ScheduleController(IUnitOfWork UnitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _UnitOfWork = UnitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Schedule> objScheduleList = _UnitOfWork.Schedule.GetAll(includeProperties: "Course").ToList();

            return View(objScheduleList);
        }
        public IActionResult Upsert(int? id)
        {
            ScheduleVM scheduleVM = new()
            {
                CourseList = _UnitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                }),
                Schedule = new Schedule()
            };
            if(id==null||id==0) return View(scheduleVM); //create
            else
            {
                //update
                scheduleVM.Schedule = _UnitOfWork.Schedule.Get(u=>u.ScheduleId == id);
                return View(scheduleVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ScheduleVM scheduleVM)
        {
            if (ModelState.IsValid)
            {
                if (scheduleVM.Schedule.ScheduleId == 0)
                {
                    _UnitOfWork.Schedule.Add(scheduleVM.Schedule);
                    TempData["success"] = "Schedule created successfully!!!";
                }
                else
                {
                    _UnitOfWork.Schedule.update(scheduleVM.Schedule);
                    TempData["success"] = "Schedule updated successfully!!!";
                }
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                scheduleVM.CourseList = _UnitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                });
                return View(scheduleVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Schedule> objScheduleList = _UnitOfWork.Schedule.GetAll(includeProperties: "Course").ToList();

            return Json(new { data = objScheduleList});
        }

        [HttpDelete]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            var scheduleToBeDeleted = _UnitOfWork.Schedule.Get(u => u.ScheduleId == id);
            if (scheduleToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _UnitOfWork.Schedule.Remove(scheduleToBeDeleted);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}