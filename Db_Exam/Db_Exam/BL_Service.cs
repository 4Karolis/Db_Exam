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
    }
}
