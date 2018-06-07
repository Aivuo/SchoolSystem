using SchoolSystem.Models;
using SchoolSystemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SchoolSystem.Controllers
{
    public class HomeController : Controller
    {
        SchoolSystemDb _db = new SchoolSystemDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            var model = _db.Courses.ToList();

            return View(model);
        }

        public ActionResult Contact()
        {
            _db.SaveChanges();
            ViewBag.Message = "Your contact page.";

            var model2 = _db.Assignments.Find(1);


            var model = model2.Course;

            return View(model);
        }

        public ActionResult Edit()
        {

            return View();
        }

        public ActionResult Details(int? id)
        {

            Course course = _db.Courses.Find(id);

            return View(course);
        }

        public ActionResult Students(int id)
        {

            //var model = _db.Courses.Find(id);

            var model = _db.Courses.Include("CourseStudents")
                                    .Include("CourseTeachers")
                                    .Include("CourseAssignments")
                                    .ToList().Find(x => x.CourseId == id);
            CoursesViewModel coursesViewModel = new CoursesViewModel(model);
                                    //
                                    //.CourseStudents
                                    //.ToList();
            //var model = model2.Find(x => x.CourseId == id).CourseStudents.ToList();


            if (coursesViewModel == null)
            {
                return RedirectToAction("Index");
            }

            return PartialView("_Details", coursesViewModel);
        }

        public ActionResult Delete()
        {

            return View();
        }
    }
}