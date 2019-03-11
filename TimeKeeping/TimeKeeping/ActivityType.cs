using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class ActivityType
    {
        [Key]
        public Guid Activity_TypeID { get; set; }
        [Required]
        public string Activity_Type { get; set; }
    }
}
