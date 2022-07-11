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
        public DateTime? DateOfBirth { get; set; }
        public List<Lecture> Lectures { get; set; }
        public int DepartmentId { get;set; }
        public Department Department { get; set; }
        public Student(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Lectures = new List<Lecture>();
            //StudentDepartment = new Department();
            //add StudentDepartment = new Department();?
            //NEW DEPO missing!
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, Department department)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Lectures = new List<Lecture>();
            Department = department;
        }
        public Student(string firstName, string lastName, DateTime dateOfBirth, Department department, List<Lecture> lectures)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
            Lectures = lectures;
            Department = department;
        }
        private Student() { }
    }
}
