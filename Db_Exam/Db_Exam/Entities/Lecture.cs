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

        public Lecture()
        {
            LectureDepartments = new List<Department>();
        }
        //private Lecture() { }
    }
}
