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
    [Authorize(Roles = SD.Role_Admin)]
    public class StudentController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public StudentController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Student> objStudentList = _UnitOfWork.Student.GetAll().ToList();
            return View(objStudentList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Student.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Student created successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Student? StudentFromDb = _UnitOfWork.Student.Get(u => u.Mssv == id);
            if (StudentFromDb == null) return NotFound();

            return View(StudentFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Student obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Student.update(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Student updated successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Student? StudentFromDb = _UnitOfWork.Student.Get(u => u.Mssv == id);
            if (StudentFromDb == null) return NotFound();

            return View(StudentFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Student? obj = _UnitOfWork.Student.Get(u => u.Mssv == id);
            if (obj == null) return NotFound();

            if (ModelState.IsValid)
            {
                _UnitOfWork.Student.Remove(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Course deleted successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}