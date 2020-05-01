using AutoMapper;
using ContosoUniversity.DTOs;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentController(IStudentService studentService,
             IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var data = await studentService.GetAll();

            var listStudents = data.Select(x => mapper.Map<StudentDTO>(x)).ToList();

            return View(listStudents);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                //Forma larga de implementar el DTO
                // var student = new Student
                // {
                //   FirstMidName = studentDTO.FirstMidName,
                // LastName = studentDTO.LastName,
                //EnrollmentDate = studentDTO.EnrollmentDate
                // };

                var student = mapper.Map<Student>(studentDTO);
                student = await studentService.Insert(student);
                var id = student.ID;
                return RedirectToAction("Index");
            }
            return View(studentDTO);
        }


        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await studentService.GetById(id.Value);

            if (student == null)
                return NotFound();

            var studentDTO = mapper.Map<StudentDTO>(student);
            return View(studentDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentDTO studentDTO)
        {
            if (ModelState.IsValid)
            {
                var student = mapper.Map<Student>(studentDTO);

                student = await studentService.Update(student);
                return RedirectToAction("Index");

            }
            return View(studentDTO);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await studentService.GetById(id.Value);

            if (student == null)
                return NotFound();

            var studentDTO = mapper.Map<StudentDTO>(student);


            return View(studentDTO);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            await studentService.Delete(id.Value);

            return RedirectToAction("Index");
        }

        /*
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        //ctrl + k + s

        try
        {
            await studentService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (System.Exception ex)
        {
            ViewBag.Message = ex.Message;
            ViewBag.Type = "danger";

            return View("Delete");
        }
    } */






    }
}