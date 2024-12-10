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
    public class LecturerController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public LecturerController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Lecturer> objLecturerList = _UnitOfWork.Lecturer.GetAll().ToList();
            return View(objLecturerList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lecturer obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Lecturer.Add(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Lecturer created successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Lecturer? LecturerFromDb = _UnitOfWork.Lecturer.Get(u => u.LID == id);
            if (LecturerFromDb == null) return NotFound();

            return View(LecturerFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Lecturer obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Lecturer.update(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Lecturer updated successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Lecturer? LecturerFromDb = _UnitOfWork.Lecturer.Get(u => u.LID == id);
            if (LecturerFromDb == null) return NotFound();

            return View(LecturerFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Lecturer? obj = _UnitOfWork.Lecturer.Get(u => u.LID == id);
            if (obj == null) return NotFound();

            if (ModelState.IsValid)
            {
                _UnitOfWork.Lecturer.Remove(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Course deleted successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}