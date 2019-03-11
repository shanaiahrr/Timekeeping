using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentID { get; set; }
        [Required]
        public string Department_Code { get; set; }
        [Required]
        public string DepartmentName { get; set; }
    }
}
