using ContosoUniversity.Models;
using ContosoUniversity.Repositories;
using ContosoUniversity.Repositories.Implements;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Services.Implements
{
    public class StudentService : GenericService<Student>, IStudentService
{
        private IStudentRepository studentRepository;

        public StudentService(IStudentRepository studentRepository) : base(studentRepository)
        {
            this.studentRepository = studentRepository;

        }

        public Task<IEnumerable<Course>> GetCoursesByStudent(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Course>> GetCursosByStudent(int id)
        {

            return await studentRepository.GetCursosByStudent(id);
            //throw new NotImplementedException();
        }

        Task IStudentService.GetCursosByStudent(int value)
        {
            throw new NotImplementedException();
        }
    }
}
