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
    }
}
