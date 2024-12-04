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
using mymvc.DataAccess.Repository.IRepository;
using mymvc.Models;
using mymvc.Models.ViewModels;
using mymvc.Utility;

namespace mymvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class TestController : Controller
    {
        private readonly IUnitOfWork _UnitOfWork;
        public TestController(IUnitOfWork UnitOfWork)
        {
            _UnitOfWork = UnitOfWork;
        }
        public IActionResult Index()
        {
            List<Test> objTestList = _UnitOfWork.Test.GetAll().ToList();

            foreach (Test icle in objTestList)
            {
                icle.Course = _UnitOfWork.Course.Get(u => u.CourseId == icle.CourseId);
            }

            return View(objTestList);
        }
        public IActionResult Create()
        {
            TestVM testVM = new TestVM()
            {
                CourseList = _UnitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                }),
                Test = new Test()
            };
            return View(testVM);
        }
        [HttpPost]
        public IActionResult Create(TestVM obj)
        {
            if (ModelState.IsValid)
            {
                if (_UnitOfWork.Test.GetAll().Count(p => p.TESTID!=null) == 0)
                    obj.Test.TESTID = 1;
                else
                    obj.Test.TESTID = _UnitOfWork.Test.GetAll().Max(p => p.TESTID) + 1;
                _UnitOfWork.Test.Add(obj.Test);
                _UnitOfWork.Save();
                TempData["success"] = "Test created successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Edit(int? ID)
        {
            if (ID == null) return NotFound();

            TestVM testVM = new TestVM()
            {
                Test = _UnitOfWork.Test.Get(u => u.TESTID == ID),
                CourseList = _UnitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                })
            };

            if (testVM.Test == null) return NotFound();

            return View(testVM);
        }
        [HttpPost]
        public IActionResult Edit(TestVM obj)
        {
            if (ModelState.IsValid)
            {
                _UnitOfWork.Test.update(obj.Test);
                _UnitOfWork.Save();
                TempData["success"] = "Test updated successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            TestVM testVM = new TestVM()
            {
                Test = _UnitOfWork.Test.Get(u => u.TESTID == id),
                CourseList = _UnitOfWork.Course.GetAll().Select(u => new SelectListItem
                {
                    Text = u.CourseName,
                    Value = u.CourseId.ToString()
                })
            };

            if (testVM.Test == null) return NotFound();

            return View(testVM);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Test? obj = _UnitOfWork.Test.Get(u => u.TESTID == id);
            if (obj == null) return NotFound();

            if (ModelState.IsValid)
            {
                _UnitOfWork.Test.Remove(obj);
                _UnitOfWork.Save();
                TempData["success"] = "Test deleted successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}