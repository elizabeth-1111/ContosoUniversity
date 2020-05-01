using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Repositories.Implementation;


    namespace ContosoUniversity.Repositories.Implements
    {
        public class StudentRepository : GenericRepository<Student>, IStudentRepository
        {
            public StudentRepository(SchoolContext context) : base(context)
            {

            }
        }
    }
