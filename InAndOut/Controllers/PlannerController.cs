using InAndOut.Data;
using InAndOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace InAndOut.Controllers
{
    public class PlannerController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PlannerController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<PlannerModel> objList = _db.Planner;
            return View(objList);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PlannerModel obj)
        {
            obj.DateTime = DateTime.Now;
            _db.Planner.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Planner.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Planner.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Planner.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var obj = _db.Planner.Find(id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(PlannerModel obj)
        {
            if (ModelState.IsValid)
            {
                obj.UpdateTime = DateTime.Now;
                _db.Planner.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

       [HttpGet]
        public IActionResult Done(int? id)
        {
            var obj = _db.Planner.Find(id);
            obj.IsDone = true;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
