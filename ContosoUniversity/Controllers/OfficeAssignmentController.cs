using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using AutoMapper;
using ContosoUniversity.DTOs;

namespace ContosoUniversity.Controllers
{
    public class OfficeAssignmentsController : Controller
    {
        //private readonly SchoolContext _context;

        private readonly IOfficeAssignmentService officeAssignmentService;
        private readonly IInstructorService instructorService;
        private readonly IMapper mapper;


        public OfficeAssignmentsController(IMapper mapper, IOfficeAssignmentService officeAssignmentService, IInstructorService instructorService)
        {
            this.officeAssignmentService = officeAssignmentService;
            this.instructorService = instructorService;
            this.mapper = mapper;

        }

        // GET: OfficeAssignments
        public async Task<IActionResult> Index()
        {
            var data1 = await officeAssignmentService.GetAll();
            var listofficeAssignment = data1.Select(x => mapper.Map<OfficeAssignmentDTO>(x)).ToList();

            return View(listofficeAssignment);
        }

        // GET: OfficeAssignments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await officeAssignmentService.GetById(id.Value);
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);




            return View(officeAssignmentDTO);
        }

        // GET: OfficeAssignments/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Instructors = await instructorService.GetAll();
            return View();
        }

        // POST: OfficeAssignments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OfficeAssignmentDTO officeAssignmentDTO)
        {
            if (ModelState.IsValid)
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);
                officeAssignment = await officeAssignmentService.Insert(officeAssignment);
                var id = officeAssignment.InstructorID;

                return RedirectToAction(nameof(Index));

            }


            return View(officeAssignmentDTO);
        }

        // GET: OfficeAssignments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await officeAssignmentService.GetById(id.Value);
            if (officeAssignment == null)
            {
                return NotFound();
            }
            ViewBag.Instructors = await instructorService.GetAll();
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);

            return View(officeAssignmentDTO);
        }

        // POST: OfficeAssignments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfficeAssignmentDTO officeAssignmentDTO)
        {

            if (ModelState.IsValid)
            {
                var officeAssignment = mapper.Map<OfficeAssignment>(officeAssignmentDTO);
                officeAssignment = await officeAssignmentService.Update(officeAssignment);
                return RedirectToAction(nameof(Index));
            }
            return View(officeAssignmentDTO);
        }

        // GET: OfficeAssignments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var officeAssignment = await officeAssignmentService.GetById(id.Value);
            var officeAssignmentDTO = mapper.Map<OfficeAssignmentDTO>(officeAssignment);
            if (officeAssignment == null)
            {
                return NotFound();
            }

            return View(officeAssignmentDTO);
        }

        // POST: OfficeAssignments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await officeAssignmentService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
                ViewBag.Type = "danger";

                return View("Delete");

            }
        }

        //private bool OfficeAssignmentExists(int id)
        //{
        //    return _context.OfficeAssignment.Any(e => e.InstructorID == id);
        //}
    }
}