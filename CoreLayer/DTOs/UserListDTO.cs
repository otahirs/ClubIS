using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public AccountState AccountState { get; set; }
    }
}