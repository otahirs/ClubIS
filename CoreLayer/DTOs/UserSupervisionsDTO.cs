using System.Collections;
using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserSupervisionsDTO
    {
        public int UserId { get; set; }
        public List<UserListDTO> EntriesSupervisors { get; set; }
        public List<UserListDTO> EntriesSupervisedUsers { get; set; }
        public List<UserListDTO> FinanceSupervisors { get; set; }
        public List<UserListDTO> FinanceSupervisedUsers { get; set; }
    }
}