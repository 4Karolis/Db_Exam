using Db_Exam.Entities;

namespace Db_Exam
{
    public class BL_Service
    {
        private readonly DbRepository _dbRepository;
        public BL_Service()
        {
            _dbRepository = new DbRepository(); 
        }

        #region ASSIGN
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
        public void AssignStudentToDepartment(int departmentId, int studentId)
        {
            var department = _dbRepository.GetDepartmentById2(departmentId);
            var student = _dbRepository.GetStudentById(studentId);
            department.Students.Add(student);
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
        }
        public void AssignLectureToDepartment(string lectureName, int depatmentId)
        {
            var lecture = _dbRepository.GetLectureByName(lectureName);
            var department = _dbRepository.GetDepartmentById2(depatmentId);
            department.Lectures.Add(lecture);
            _dbRepository.UpdateDepartment(department);
            _dbRepository.SaveChanges();
        }
        #endregion

        #region GET
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
        public List<Student> GetStudentsByDepartmentId(int departmentId)
        {
            return _dbRepository.GetStudentsByDepartmentId(departmentId);
        }
        public Student GetStudentById(int studentId)
        {
            return _dbRepository.GetStudentById(studentId);
        }
        public Department GetDepartmentById(int id)
        {
            return _dbRepository.GetDepartmentById2(id);
        }
        public List<Lecture> GetAllLectures()
        {
            return _dbRepository.GetAllLectures();
        }
        public List<Department> GetAllDepartments()
        {
            return _dbRepository.GetAllDepartments();
        }
        public List<Student> GetAllStudents()
        {
            return _dbRepository.GetAllStudents();
        }
        #endregion

        #region CREATE + UPDATE       
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
