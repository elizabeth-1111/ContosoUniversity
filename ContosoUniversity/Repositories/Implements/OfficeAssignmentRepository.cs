using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Repositories.Implements
{
    public class OfficeAssignmentRepository : GenericRepository<OfficeAssignment>, IOfficeAssignmentRepository
    {
        private SchoolContext schoolContext;

        public OfficeAssignmentRepository(SchoolContext schoolcontext) : base(schoolcontext)
        {
            this.schoolContext = schoolcontext;
        }

        public new async Task<List<OfficeAssignment>> GetAll()
        {

            var listOfficeAssignment = await schoolContext.OfficeAssignment
                .Include(x => x.Instructor)
                .ToListAsync();

            return listOfficeAssignment;
        }


    }
}
