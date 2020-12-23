using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        Task Create(UserEditDTO e);
        Task<IEnumerable<UserListDTO>> GetAll();
        Task<UserDetailDTO> GetById(int id);
        Task Update(UserEditDTO e);
        Task Delete(int id);
        Task UpdateLogin(UserCredentialsEditDTO user);
        Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors();
        Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id);
    }
}
