using Db_Exam.Entities;
using Microsoft.EntityFrameworkCore;

namespace Db_Exam
{
    public class ExamDbContext : DbContext
    {
        public DbSet<Department> Departments { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database=DatabaseExamDb;Trusted_Connection=True;");
        }
    }
}
