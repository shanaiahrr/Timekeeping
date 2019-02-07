using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Models
{
    public class Roles
    {
        [Key]
        public Guid RoleID { get; set; }

        [Required]
        public string RoleName { get; set; }

    }
}
