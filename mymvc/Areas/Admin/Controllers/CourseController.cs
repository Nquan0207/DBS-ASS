using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mymvc.DataAccess.Data;
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;
using mymvc.Utility;

namespace mymvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin + "," + SD.Role_Student)]
    public class CourseController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public CourseController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        
        public IActionResult Index()
        {
            List<Course> objCourseList = _UnitOfWork.Course.GetAll().ToList();
            return View(objCourseList);
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Create(Course obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Course.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Course created successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Course? CourseFromDb = _UnitOfWork.Course.Get(u => u.CourseId == id);
            if (CourseFromDb == null) return NotFound();

            return View(CourseFromDb);
        }
        [HttpPost]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Edit(Course obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Course.update(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Course updated successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Course? CourseFromDb = _UnitOfWork.Course.Get(u => u.CourseId == id);
            if (CourseFromDb == null) return NotFound();

            return View(CourseFromDb);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = SD.Role_Admin)]
        public IActionResult DeletePOST(int? id)
        {
            Course? obj = _UnitOfWork.Course.Get(u => u.CourseId == id);
            if (obj == null) return NotFound();

            if (ModelState.IsValid)
            {
                _UnitOfWork.Course.Remove(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Course deleted successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}