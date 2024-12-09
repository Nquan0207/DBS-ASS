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
    [PrimaryKey(nameof(CourseId), nameof(LID))]
    public class Monitor
    {
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        [ValidateNever]
        public Course Course { get; set; }

        public int? LID { get; set; }

        [ForeignKey("LID")]
        [ValidateNever]
        public Lecturer Lecturer { get; set; }
    }
}
