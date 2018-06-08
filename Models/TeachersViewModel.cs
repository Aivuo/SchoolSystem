using SchoolSystemClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolSystem.Models
{
    public class TeachersViewModel
    {
        public int TeacherId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public List<Course> Courses { get; set; }

        public TeachersViewModel(Teacher teacher)
        {
            TeacherId = teacher.TeacherId;
            FirstName = teacher.FirstName;
            MiddleName = teacher.MiddleName;
            LastName = teacher.LastName;

            Courses = new List<Course>();

            foreach (var item in teacher.Courses)
            {
                Courses.Add(item);
            }

        }
    }
}