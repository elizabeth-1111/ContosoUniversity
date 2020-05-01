using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implementation;

namespace ContosoUniversity.Repositories.Implements
{
    public class EnrollmentRepository :GenericRepository<Enrollment>, IEnrollmentRepository
    {
        private SchoolContext schoolContext;

    public EnrollmentRepository(SchoolContext schoolContext) : base(schoolContext)
    {
        this.schoolContext = schoolContext;
    }

    
    }
}
