using System;
using System.Collections.Generic;
using System.Text;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserInfoDTO
    {
        public bool IsAuthenticated { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public Dictionary<string, string> ExposedClaims { get; set; }
    }
}
