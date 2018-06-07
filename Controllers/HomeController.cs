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

        public ActionResult Edit(int Id)
        {
            var model = _db.Courses.Include("CourseStudents")
                        .Include("CourseTeachers")
                        .Include("CourseAssignments")
                        .ToList().Find(x => x.CourseId == Id);
            CoursesViewModel coursesViewModel = new CoursesViewModel(model);


            return View(coursesViewModel);
        }

        [HttpPost]
        public ActionResult Edit(string CourseName, string CourseSubject, int id)
        {
            var course = _db.Courses.Find(id);

            if (course != null)
            {
                course.CourseName = CourseName;
                course.CourseSubject = CourseSubject;
            }

            _db.SaveChanges();

            return RedirectToAction("About");
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

        public ActionResult Add()
        {
            List<CoursesViewModel> ViewModels = new List<CoursesViewModel>();

            var model = _db.Courses.Include("CourseStudents")
                                    .Include("CourseTeachers")
                                    .Include("CourseAssignments")
                                    .ToList();
            foreach (var item in model)
            {

                ViewModels.Add(new CoursesViewModel(item));
            }

            return View(ViewModels);
        }

        [HttpPost]
        public ActionResult Add(string FirstnameIn, string LastnameIn, params int[] Assignments)
        {
            Student student = new Student
            {
                FirstName = FirstnameIn,
                LastName = LastnameIn
            };

            foreach (var item in Assignments)
            {
                var assignment = _db.Courses.Find(item);

                student.Courses.Add(assignment);
            }

            _db.Students.Add(student);

            _db.SaveChanges();
            return RedirectToAction("About");
        }

        public ActionResult Delete()
        {

            return View();
        }
    }
}