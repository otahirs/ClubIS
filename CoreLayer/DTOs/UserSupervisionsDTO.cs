using System.Collections.Generic;

namespace ClubIS.CoreLayer.DTOs
{
    public class UserSupervisionsDTO
    {
        public int UserId { get; set; }
        public ISet<UserListDTO> EntriesSupervisors { get; set; }
        public ISet<UserListDTO> EntriesSupervisedUsers { get; set; }
        public UserListDTO FinanceSupervisor { get; set; }
        public ISet<UserListDTO> FinanceSupervisedUsers { get; set; }
    }
}
