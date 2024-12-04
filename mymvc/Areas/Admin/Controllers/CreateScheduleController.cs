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
            List<CreateSchedule> objCreateScheduleList = _UnitOfWork.CreateSchedule.GetAll(includeProperties: "CreateSchedule").ToList();

            return View(objCreateScheduleList);
        }
        public IActionResult Upsert(int? id)
        {
            ScheduleVM scheduleVM = new()
            {
                CreateScheduleList = _UnitOfWork.CreateSchedule.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ScheduleIdRe.ToString(),
                    Value = u.MssvRe.ToString()
                }),
                CreateSchedule = new CreateSchedule()
            };
            if (id == null || id == 0) return View(scheduleVM); //create
            else
            {
                //update
                scheduleVM.CreateSchedule = _UnitOfWork.CreateSchedule.Get(u => u.ScheduleIdRe == id);
                return View(scheduleVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(ScheduleVM scheduleVM)
        {
            if (ModelState.IsValid)
            {
                if (scheduleVM.CreateSchedule.ScheduleIdRe == 0)
                {
                    _UnitOfWork.CreateSchedule.Add(scheduleVM.CreateSchedule);
                    TempData["success"] = "CreateSchedule created successfully!!!";
                }
                else
                {
                    _UnitOfWork.CreateSchedule.update(scheduleVM.CreateSchedule);
                    TempData["success"] = "CreateSchedule updated successfully!!!";
                }
                _UnitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                scheduleVM.CreateScheduleList = _UnitOfWork.CreateSchedule.GetAll().Select(u => new SelectListItem
                {
                    Text = u.ScheduleIdRe.ToString(),
                    Value = u.MssvRe.ToString()
                });
                return View(scheduleVM);
            }
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            List<CreateSchedule> objCreateScheduleList = _UnitOfWork.CreateSchedule.GetAll(includeProperties: "CreateSchedule").ToList();
            return Json(new { data = objCreateScheduleList });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var scheduleToBeDeleted = _UnitOfWork.CreateSchedule.Get(u => u.ScheduleIdRe == id);
            if (scheduleToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _UnitOfWork.CreateSchedule.Remove(scheduleToBeDeleted);
            _UnitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}