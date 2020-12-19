using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.DTOs;

namespace clubIS.BusinessLayer.Services.Interfaces
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
    }
}
