using System.Collections.Generic;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserPermListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public AccountState AccountState { get; set; }
        public IEnumerable<string> Permissions { get; set; }
    }
}