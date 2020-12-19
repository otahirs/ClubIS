using System;
using System.Collections.Generic;
using System.Text;
using clubIS.CoreLayer.Enums;

namespace clubIS.CoreLayer.DTOs
{
    public class UserAdministrationDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public AccountState AccountState { get; set; }
        public Role Roles { get; set; }
    }
}
