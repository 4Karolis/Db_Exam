using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public List<Lecture> StudentLectures { get; set; }
        public Department StudentDepartment { get; set; }
        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            StudentLectures = new List<Lecture>();
            //StudentDepartment = new Department();
            //add StudentDepartment = new Department();?
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, Department studentDepartment)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            StudentLectures = new List<Lecture>();
            StudentDepartment = studentDepartment;
        }
        private Student() { }
    }
}
