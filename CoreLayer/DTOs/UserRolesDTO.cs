using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserRolesDTO
    {
        public int UserId { get; set; }
        public IList<string> Roles { get; set; }
    }
}
