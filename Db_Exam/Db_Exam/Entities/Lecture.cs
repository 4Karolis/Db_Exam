using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam.Entities
{
    public class Lecture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> LectureDepartments { get; set; }

        public Lecture(string name)
        {
            Name = name;
            LectureDepartments = new List<Department>();
        }
        //public Lecture(string name, Department department)
        //{
        //    Name = name;
        //    LectureDepartments = LectureDepartments.Add(department);
        //}
        private Lecture() { }
    }
}
