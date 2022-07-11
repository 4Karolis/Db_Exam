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
        //public void AddLectureToDepartment(Department department, Lecture lecture)
        //{
        //    _dbContext.Lectures.Add(lecture);
        //}
        public Student GetStudentById(int studentId)
        {
            return _dbContext.Students.FirstOrDefault(s=>s.Id == studentId);
        }
        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }
        public Lecture GetLectureById(int lectureId)
        {
            return _dbContext.Lectures.FirstOrDefault(l => l.Id == lectureId);
        }
        public List<Lecture> GetAllLectures()
        {
            return _dbContext.Lectures.ToList();
        }
        public Lecture GetLectureByName(string name)
        {
            return _dbContext.Lectures.FirstOrDefault(l => l.Name == name);
        }
        //public Department GetDepartmentByName(string name)
        //{
        //    return _dbContext.Departments.FirstOrDefault(d => d.Name == name);
        //}
        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            //return _dbContext.Students.Where(s => s.StudentDepartment.Id = departmentId).Tolist();
            return _dbContext.Students.Where(s => s.Department.Id == departmentId).ToList();
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
        public void UpdateStudent(Student student)
        {
            _dbContext.Attach(student);
        }
        public void Updatelecture(Lecture lecture)
        {
            _dbContext.Attach(lecture); // prijungia objekta prie EF tracker
        }
        public void UpdateDepartment(Department department)
        {
            _dbContext.Attach(department); // prijungia objekta prie EF tracker
        }
        public Student GetStudentById2(int studentId)
        {
            return _dbContext.Students.Include(s => s.Department).Include(s => s.Lectures).FirstOrDefault(s => s.Id == studentId);
        }
        public Lecture GetLectById(int lectureId)
        {
            return _dbContext.Lectures.Include(l => l.Departments).FirstOrDefault(l => l.Id == lectureId);
        }
        public Department GetDepartmentByName(string departmentName)
        {
            return _dbContext.Departments.Include(d => d.Students).Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);
        }
        public Department GetDepartmentById2(int id)
        {
            return _dbContext.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Id == id);
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
