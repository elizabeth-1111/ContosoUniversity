using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 using ContosoUniversity.Models;

namespace ContosoUniversity.Repositories
{
    interface IInstructorRepository : IGenericRepository<Instructor>
    {
        Task<IEnumerable<Course>> GetCursosByInstructor(int id);

        Task<IEnumerable<Enrollment>> GetEnrollmentsByCurso(int id);

    }

}

   