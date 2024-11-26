using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mymvc.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Credit must be between 1 and 10.")]
        public int Credit { get; set; }

        [Required]
        public string Department { get; set; }

        public string? Description { get; set; }
    }
}
