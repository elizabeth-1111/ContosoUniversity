using AutoMapper;
using ContosoUniversity.DTOs;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
    public class CoursesController : Controller
    {
        private ICourseService courseService;
        private readonly IMapper mapper;

        public CoursesController(ICourseService courseService,
            IMapper mapper)
        {
            this.courseService = courseService;
            this.mapper = mapper;
        }

        // GET: Courses
        public async Task<IActionResult> Index(int? id)
        {


            if (id != null)
            {
                var dataStudent = await courseService.GetStudentsByCourse(id.Value);
                ViewBag.Students = dataStudent.Select(x => mapper.Map<StudentDTO>(x)).ToList();
            }
            var data = await courseService.GetAll();
            var listCourse = data.Select(x => mapper.Map<CourseDTO>(x)).ToList();

            return View(listCourse);


        }



        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await courseService.GetById(id.Value);

            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);

            return View(courseDTO);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseDTO courseDTO)
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

                var course = mapper.Map<Course>(courseDTO);
                course = await courseService.Insert(course);
                var id = course.CourseID;
                return RedirectToAction("Index");
            }
            return View(courseDTO);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await courseService.GetById(id.Value);

            if (course == null)
                return NotFound();

            var courseDTO = mapper.Map<CourseDTO>(course);
            return View(courseDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(CourseDTO coursetDTO)
        {
            if (ModelState.IsValid)
            {
                var course = mapper.Map<Course>(coursetDTO);

                course = await courseService.Update(course);
                return RedirectToAction("Index");

            }
            return View(coursetDTO);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var course = await courseService.GetById(id.Value);

            if (course == null)
                return NotFound();


            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            //ctrl + k + s

            try
            {
                await courseService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (System.Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");
            }
        }
    }
}
