using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Models
{
    public class RoleRights
    {
        [Key]
        public Guid Role_RightID { get; set; }

        public Guid RightID { get; set; }
        [ForeignKey("RightID")]
        public Rights Right { get; set; }

        public Guid RoleID { get; set; }
        [ForeignKey("RoleID")]
        public Roles Role { get; set; }
    }
}
