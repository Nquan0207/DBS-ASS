using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mymvc.Models.ViewModels
{
    public class CreateScheduleVM
    {
        public List<Student> Students { get; set; }
        public List<Schedule> Schedules { get; set; }
        public List<CreateSchedule> CreateSchedules { get; set; }
        public int ListCount { get; set; }
    }
    public class CreateScheduleStudentVM
    {
        public Student Student { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> StudentList { get; set; }
        public int? Mssv { get; set; }
    }
    public class CreateScheduleScheduleVM
    {
        public Schedule Schedule { get; set; }
        public CreateSchedule CreateSchedules { get; set; }
        public bool IsCreate { get; set; }
        public int ScheduleID { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> ScheduleList { get; set; }
    }
}