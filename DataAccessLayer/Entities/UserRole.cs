using DataAccessLayer.Enums;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public Role Role { get; set; }
    }
}
