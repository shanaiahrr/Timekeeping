using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Days
    {
        [Key]
       public Guid DayID { get; set; }

       public string Day { get; set; }
    }

}
