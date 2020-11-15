using DataAccessLayer.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class UserAdministrationDTO
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public AccountState AccountState { get; set; }
        public Role Roles { get; set; }
    }
}
