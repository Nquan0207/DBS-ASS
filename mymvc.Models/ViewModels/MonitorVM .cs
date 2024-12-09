using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mymvc.Models.ViewModels
{
    public class MonitorIndexVM
    {
        public List<Lecturer> Lecturer { get; set; }
        public List<Course> Course { get; set; }
        public List<Monitor> Monitor { get; set; }
        public int ListCount { get; set; }
    }
    public class MonitorLecturerVM
    {
        public Lecturer Lecturer { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> LecturerList { get; set; }
        public int? CourseID { get; set; }
        public string? Department { get; set; }
    }
    public class MonitorCourseVM
    {
        public Course Course { get; set; }
        public Monitor Monitor { get; set; }
        public bool IsCreate { get; set; }
        public int LID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
    }
}
