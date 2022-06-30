using Db_Exam.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam
{
    public class BL_Service
    {
        private readonly DbRepository _dbRepository;
        public BL_Service()
        {
            _dbRepository = new DbRepository(); 
        }
        public Department GetDepartmentById(int id)
        {
            return _dbRepository.GetDepartmentById(id);
        }
        public List<Department> GetAllDepartments()
        {
            return _dbRepository.GetAllDepartments();
        }
        public void CreateStudentToDepartment(string firstName, string lastName, DateTime dateOfBirth, Department department)
        {
            var student = new Student(firstName, lastName, dateOfBirth, department);
            _dbRepository.AddStudent(student);
            _dbRepository.SaveChanges();
        }
        public void CreateStudent(string firstName, string lastName, DateTime dateOfBirth)
        {
            var student = new Student(firstName, lastName, dateOfBirth);
            _dbRepository.AddStudent(student);
            _dbRepository.SaveChanges();
        }
        public void CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _dbRepository.AddLecture(lecture);
            _dbRepository.SaveChanges();
        }
        public void CreateDepartment(string name)
        {
            var department = new Department(name);
            _dbRepository.AddDepartment(department);
            _dbRepository.SaveChanges();
        }
    }
}
