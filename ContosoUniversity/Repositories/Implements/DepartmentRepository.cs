using ContosoUniversity.Data;
using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
    {

        private SchoolContext schoolContext;

        public DepartmentRepository(SchoolContext schoolcontext) : base(schoolcontext)
        {
            this.schoolContext = schoolcontext;
        }
    }
}
