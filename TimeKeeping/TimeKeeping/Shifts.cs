using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Shifts
    {
        [Key]
        public Guid ShiftID { get; set; }

        [Required]
        public string Shift_Type { get; set; }

        public DateTime Start_Time { get; set; }

        public DateTime End_Time { get; set; }

        public DateTime StartDate { get; set; }
        public Guid DayID { get; set; }
        [ForeignKey("DayID")]
        public Days Day { get; set; }
    }
}
