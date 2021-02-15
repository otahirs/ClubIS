using ClubIS.CoreLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(UserDTO e);
        Task<IEnumerable<UserListDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task Update(UserDTO e);
        Task Update(MemberUserEditDTO e);
        Task UpdateSupervisions(UserSupervisionsDTO user);
        Task Delete(int id);
        Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors();
        Task<UserSupervisionsDTO> GetUserSupervisions(int id);

        Task<EntryUserListDTO> GetEntryUser(int id);
        Task<IEnumerable<EntryUserListDTO>> GetEntrySupervisedUsers(int id);
        Task<IEnumerable<EntryUserListDTO>> GetEntryAllUsers();
    }
}
