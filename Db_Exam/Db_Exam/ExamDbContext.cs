using Db_Exam.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db_Exam
{
    public class ExamDbContext : DbContext
    {
        DbSet<Department> Departments { get; set; }
        DbSet<Lecture> Lectures { get; set; }
        DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database=ExamDb;Trusted_Connection=True;");
        }
    }
}
