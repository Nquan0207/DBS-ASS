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
    public class Lecturer
    {
        [Key]
        public int LID { get; set; }

        [Required]
        [StringLength(100)]
        public string FULL_NAME { get; set; }

        [Required]
        [StringLength(15)]
        public string PHONE_NUMBER { get; set; }

        [Required]
        [StringLength(100)]
        public string EMAIL { get; set; }

        [Required]
        [StringLength(100)]
        public string DEPARTMENT { get; set; }
    }
}
