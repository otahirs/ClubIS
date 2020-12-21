using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserEntriesSupervisedListDTO
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public List<UserListDTO> SupervisedUsers { get; set; }
    }
}
