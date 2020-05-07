using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.DTOs
{
    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }

        [Required(ErrorMessage = "The Name is required")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public decimal? Budget { get; set; }

        [Required(ErrorMessage = "The Start Date  is required")]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        //[Required(ErrorMessage = "The Instructor ID  is required")]
        //[Display(Name = "Instructor ID")]
        public int InstructorID { get; set; }
    }
}
