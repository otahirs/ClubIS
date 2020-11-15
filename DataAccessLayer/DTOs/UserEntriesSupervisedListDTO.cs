using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.DTOs
{
    class UserEntriesSupervisedListDTO
    {
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string RegistrationNumber { get; set; }
        public List<UserListDTO> SupervisedUsers { get; set; }
    }
}
