using Db_Exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam
{
    public class DbRepository
    {
        private readonly ExamDbContext _dbContext;
        public DbRepository()
        {
            _dbContext = new ExamDbContext();
        }
        public void AddLectureToDepartment(Department department, Lecture lecture)
        {

        }
        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            //return _dbContext.Students.Where(s => s.StudentDepartment.Id = departmentId).Tolist();
            return _dbContext.Students.Where(s => s.StudentDepartment.Id == departmentId).ToList();
        }
        public Department GetDepartmentById(int id)
        {
            return _dbContext.Departments.FirstOrDefault(d => d.Id == id);
        }
        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        public void AddStudent(Student student)
        {         
             _dbContext.Students.Add(student);
        }
        public void AddLecture(Lecture lecture)
        {
            _dbContext.Lectures.Add(lecture);
        }
        public void AddDepartment(Department department)
        {            
            _dbContext.Departments.Add(department);
        }
        public void SaveChanges()
        {
            try
            {
                _dbContext.SaveChanges();

            }
            catch (DbUpdateException)
            {

            }
        }
    }
}
