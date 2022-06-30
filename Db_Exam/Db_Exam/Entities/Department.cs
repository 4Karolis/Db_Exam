using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> DepartmentStudents { get; set; }
        public List<Lecture> DepartmentLectures { get; set; }
    }
}
