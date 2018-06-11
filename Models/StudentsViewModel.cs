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
        public List<Assignment> Assignments { get; set; }

        public StudentsViewModel(Student student, List<Assignment> assignments)
        {
            StudentId = student.StudentId;
            FirstName = student.FirstName;
            LastName = student.LastName;

            Courses = new List<Course>();
            Assignments = new List<Assignment>();

            foreach (var item in student.Courses)
            {
                Courses.Add(item);
                //foreach (var item2 in item.CourseAssignments)
                //{
                //    Assignments.Add(item2);
                //}
                foreach (var item2 in assignments)
                {
                    if (item2.CourseId == item.CourseId)
                    {
                        Assignments.Add(item2);
                    }
                }
            }


        }
    }
}