using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace mymvc.Models
{
    public class Student
    {
        [Key]
        public int Mssv { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        
    }
}
