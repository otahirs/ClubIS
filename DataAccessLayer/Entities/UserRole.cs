using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class UserRole : BaseEntity
    {
        public Role Role { get; set; }
    }
}
