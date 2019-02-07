using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Shifts
    {
        [Key]
        public Guid ShiftID { get; set; }

        [Required]
        public string Shift_Type { get; set; }

        public string Start_Time { get; set; }

        public string End_Time { get; set; }

        public DateTime StartDate { get; set; }

    }
}
