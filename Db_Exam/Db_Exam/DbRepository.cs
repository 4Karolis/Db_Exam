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
