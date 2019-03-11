using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class TypeofRights
    {
        [Key]
        public Guid Role_TypeID { get; set; }

        [Required]
        public string Role_Type { get; set; }
    }
}
