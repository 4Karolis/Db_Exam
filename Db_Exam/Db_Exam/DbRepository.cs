using Db_Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Db_Exam
{
    public class DbRepository
    {
        private readonly ExamDbContext _dbContext;
        public DbRepository()
        {
            _dbContext = new ExamDbContext();
        }       

        #region STUDENT
        public Student GetStudentById(int studentId)
        {
            return _dbContext.Students.Include(s => s.Department).Include(s => s.Lectures).FirstOrDefault(s => s.Id == studentId);
        }
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            return _dbContext.Students.Include(s => s.Department).Include(s => s.Lectures).Where(s => s.DepartmentId == departmentId).ToList();
        }
        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            return _dbContext.Students.Where(s => s.Department.Id == departmentId).ToList();
        }
        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }
        #endregion

        #region LECTURE
        public Lecture GetLectureByName(string name)
        {
            return _dbContext.Lectures.Include(l => l.Departments).Include(l => l.Students).FirstOrDefault(l => l.Name == name);
        }
        public List<Lecture> GetLecturesByStudentId(int studentId)
        {
            return _dbContext.Lectures.Where(l => l.Students.Any(s => s.Id == studentId)).ToList();
        }
        public Lecture GetLectureById(int lectureId)
        {
            return _dbContext.Lectures.Include(l => l.Departments).FirstOrDefault(l => l.Id == lectureId);
        }
        public List<Lecture> GetLecturesByDepartment(Department department)
        {
            return _dbContext.Lectures.Include(l => l.Students).Include(l => l.Departments).Where(l => l.Departments.Contains(department)).ToList();
        }
        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            return _dbContext.Lectures.Include(l => l.Students).Include(l => l.Departments).Where(l => l.Departments.Any(d => d.Id == departmentId)).ToList();
        }
        public List<Lecture> GetAllLectures()
        {
            return _dbContext.Lectures.ToList();
        }
        #endregion

        #region DEPARTMENT
        public Department GetDepartmentById2(int id)
        {
            return _dbContext.Departments.Include(d => d.Lectures).FirstOrDefault(d => d.Id == id);
        }
        public Department GetDepartmentByName(string departmentName)
        {
            return _dbContext.Departments.Include(d => d.Students).Include(d => d.Lectures).FirstOrDefault(d => d.Name == departmentName);
        }
        public List<Department> GetAllDepartments()
        {
            return _dbContext.Departments.ToList();
        }
        #endregion

        #region ADD + UPDATE + SAVE
        public void UpdateStudent(Student student)
        {
            _dbContext.Attach(student);
        }
        public void Updatelecture(Lecture lecture)
        {
            _dbContext.Attach(lecture);
        }
        public void UpdateDepartment(Department department)
        {
            _dbContext.Attach(department);
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
        #endregion
    }
}
