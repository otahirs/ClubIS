using ClubIS.CoreLayer.Enums;
using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserAdministrationDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public AccountState AccountState { get; set; }
        public IEnumerable<Role> Roles { get; set; }
    }
}
