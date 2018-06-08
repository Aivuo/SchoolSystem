using SchoolSystemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.Models
{
    public class StudentsViewModel
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }

        public StudentsViewModel(Student student)
        {
            StudentId = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;

            Courses = new List<Course>();

            foreach (var item in student.Courses)
            {
                Courses.Add(item);
            }
        }
    }
}