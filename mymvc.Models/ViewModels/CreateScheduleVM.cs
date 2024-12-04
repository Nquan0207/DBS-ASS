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
        public List<Student> Student { get; set; }
        public List<Schedule> Schedule { get; set; }
        public List<CreateSchedule> CreateSchedule { get; set; }
        public int ListCount { get; set; }
    }
    public class CreateScheduleStudentVM
    {
        public Student Student { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StudentList { get; set; }
        public int? ScheduleID { get; set; }
        public string? Location { get; set; }
    }
    public class CreateScheduleScheduleVM
    {
        public Schedule Schedule { get; set; }
        public CreateSchedule CreateSchedule { get; set; }
        public bool IsCreate { get; set; }
        public int Mssv { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ScheduleList { get; set; }
    }
}
