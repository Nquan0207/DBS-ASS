﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace mymvc.Models.ViewModels
{
    public class ScheduleVM
    {
        public Schedule Schedule { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CourseList { get; set; }
    }
}