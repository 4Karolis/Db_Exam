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
        public void TrasnferStudentToDepartmentWithLectures(int studentId, int departmentId)
        {
            var student = GetStudentById(studentId);
            var department = GetDepartmentById(departmentId);
            var lectures = GetLecturesByDepartmentId(departmentId);

            student.Lectures.Clear();
            student.Department = department;
            student.Lectures = lectures;
            _dbRepository.UpdateStudent(student);
            _dbRepository.SaveChanges();
        }
       
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            return _dbRepository.GetStudentsByDepartmentId(departmentId);
        }
        public Student GetStudentById(int studentId)
        {
            return _dbRepository.GetStudentById(studentId);
        }
        public List<Student> GetAllStudents()
        {
            return _dbRepository.GetAllStudents();
        }
        public List<Lecture> GetLecturesByStudentId(int studentId)
        {
            return _dbRepository.GetLecturesByStudentId(studentId);
        }
        public List<Lecture> GetLecturesByDepartment(Department department)
        {
            return _dbRepository.GetLecturesByDepartment(department);
        }
        public List<Lecture> GetLecturesByDepartmentId(int departmentId)
        {
            return _dbRepository.GetLecturesByDepartmentId(departmentId);
        }
        public Department GetDepartmentById(int id)
        {
            return _dbRepository.GetDepartmentById2(id);
        }
        public List<Department> GetAllDepartments()
        {
            return _dbRepository.GetAllDepartments();
        }
        public List<Student> GetStudentsByDepartment(int departmentId)
        {
            return _dbRepository.GetStudentsByDepartment(departmentId);
        }
        
       
        public void AssignLectureToDepartment(string lectureName, int depatmentId)
        {
            var lecture = _dbRepository.GetLectureByName(lectureName);
            var department = _dbRepository.GetDepartmentById2(depatmentId);
            department.Lectures.Add(lecture);
            _dbRepository.UpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
        public void AssignLectureToDepartment(int depatmentId, int lectureId)
        {
            var department = _dbRepository.GetDepartmentById2(depatmentId);
            var lecture = _dbRepository.GetLectureById(lectureId);
            department.Lectures.Add(lecture);
            _dbRepository.UpdateDepartment(department);
            _dbRepository.SaveChanges();
            Console.WriteLine("Lecture added successfully!");
        }
        public void AssignStudentToDepartment(int departmentId, int studentId)
        {
            var department = _dbRepository.GetDepartmentById2(departmentId);
            var student = _dbRepository.GetStudentById(studentId);
            department.Students.Add(student);
            _dbRepository.UpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
        public void AssignStudentAndLectureToDepartment(int studentId, int lectureId, string departmentName)
        {
            var student = _dbRepository.GetStudentById(studentId);
            var lecture = _dbRepository.GetLectureById(lectureId);
            var department = _dbRepository.GetDepartmentByName(departmentName);

            department.Students.Add(student);
            department.Lectures.Add(lecture);
            _dbRepository.UpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
        public void AssignLectureToDepartment2(int id, int lecId)
        {
            var depart = _dbRepository.GetDepartmentById2(id);
            var lecture = _dbRepository.GetLectureById(lecId);
            depart.Lectures.Add(lecture);
            _dbRepository.UpdateDepartment(depart);
            _dbRepository.SaveChanges();
        }
        public void AssignLectureToDepartment(string name, Department department)
        {
            var lecture = GetLectureByName(name);
            
            if (lecture.Departments.Any(d => d.Name.ToUpper() == department.Name.ToUpper()))
            {
                return;
            }
            var departmentFromDb = _dbRepository.GetDepartmentByName(department.Name);
            //var lectureFromDB = _dbRepository.GetLectureByName(name);
            lecture.Departments.Add(departmentFromDb ?? new Department(department.Name));

            _dbRepository.Updatelecture(lecture);
            _dbRepository.SaveChanges();
        }       
        public Lecture GetLectureById(int lectureId)
        {
            return _dbRepository.GetLectureById(lectureId);
        }       
        public List<Lecture> GetAllLectures()
        {
            return _dbRepository.GetAllLectures();
        }
        public Lecture GetLectureByName(string name)
        {
            return _dbRepository.GetLectureByName(name);
        }




        #region GET

        #endregion

        #region CREATE + UPDATE
        public void CreateLectureToDepartment(string name, Department department)
        {
            var lecture = new Lecture(name);
            _dbRepository.AddLecture(lecture);
            _dbRepository.SaveChanges();
            AssignLectureToDepartment(name, department);
        }
        public void CreateStudentToDepartmentWithLectures(string firstName, string lastName, DateTime dateOfBirth, Department department, List<Lecture> lectures)
        {
            var departmentLectures = GetLecturesByDepartment(department);
            var student = new Student(firstName, lastName, dateOfBirth, department, departmentLectures);
            _dbRepository.AddStudent(student);
            _dbRepository.SaveChanges();
        }
        public void CreateStudentToDepartment(string firstName, string lastName, DateTime dateOfBirth, Department department)
        {
            var student = new Student(firstName, lastName, dateOfBirth, department);
            _dbRepository.AddStudent(student);
            _dbRepository.SaveChanges();
        }
        public void CreateDepartment(string name)
        {
            var department = new Department(name);
            _dbRepository.AddDepartment(department);
            _dbRepository.SaveChanges();
        }
        public void CreateLecture(string name)
        {
            var lecture = new Lecture(name);
            _dbRepository.AddLecture(lecture);
            _dbRepository.SaveChanges();
        }
        public void CreateStudent(string firstName, string lastName, DateTime dateOfBirth)
        {
            var student = new Student(firstName, lastName, dateOfBirth);
            _dbRepository.AddStudent(student);
            _dbRepository.SaveChanges();
        }
        public void UpdateLecture(Lecture lecture)
        {
            _dbRepository.Updatelecture(lecture);
        }
        #endregion
    }
}
