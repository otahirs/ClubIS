using System;
using System.Collections.Generic;
using System.Text;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserRolesDTO
    {
        public int UserId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
