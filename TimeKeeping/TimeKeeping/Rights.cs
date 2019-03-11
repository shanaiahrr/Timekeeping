using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class Rights
    {
        [Key]
        public Guid RightID { get; set; }

        [Required]
        public string NameofRight { get; set; }

        public Guid TypeID { get; set; }
        [ForeignKey("TypeID")]
        public TypeofRights TypeofRight { get; set; }
    }
}
