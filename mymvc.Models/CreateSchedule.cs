using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

namespace mymvc.Models
{
    [PrimaryKey(nameof(Mssv), nameof(ScheduleID))]
    public class CreateSchedule
    {
        public int Mssv { get; set; }

        [ForeignKey("Mssv")]
        [ValidateNever]
        public Student Student { get; set; }

        public int? ScheduleID { get; set; }

        [ForeignKey("ScheduleID")]
        [ValidateNever]
        public Schedule Schedule { get; set; }
    }
}
