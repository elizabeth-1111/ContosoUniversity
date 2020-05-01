using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace ContosoUniversity.Services.Implements
{
    public class EnrollmentService : GenericService<Enrollment>, IEnrollmentService
    {
        private IEnrollmentRepository enrollmentRepository;

        public EnrollmentService(IEnrollmentRepository enrollmetnRepository) : base(enrollmetnRepository)
        {
            this.enrollmentRepository = enrollmetnRepository;
        }

    }
}
