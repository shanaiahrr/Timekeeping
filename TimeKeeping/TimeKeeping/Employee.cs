using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Employee
    {
        [Required]
        public string LastName { get; set; }

        public string MiddleName { get; set; }
        [Required]
        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return string.Format($"{FirstName} {LastName}");
            }
        }

        [Required]
        public string Gender { get; set; }
        [Required]
        public DateTime Birthdate { get; set; }
        [Required]
        public DateTime HiredDate { get; set; }
        [Key]
        public string EmployeeID { get; set; }
        public string EmployeeStatus { get; set; }
        public string Position { get; set; }
        public string Department { get; set; }
        public string Project { get; set; }
        public string CostCenter { get; set; }
        public DateTime SeparatedDate { get; set; }

        public string Shift { get; set; }
        [Required]
        public string SSSno { get; set; }
        [Required]
        public string PHICno { get; set; }
        [Required]
        public string TINno { get; set; }
        [Required]
        public string HDMFno { get; set; }
        public Guid RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Roles Role { get; set; }

    }
}
