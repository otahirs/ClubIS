using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IUserService
    {
        public Task Create(UserEditDTO e);
        public Task<IEnumerable<UserListDTO>> GetAll();
        public Task<UserDetailDTO> GetById(int id);
        public Task Update(UserEditDTO e);
        public void Delete(int id);
        public Task UpdateLogin(UserCredentialsEditDTO user);
        public Task<UserEntriesSupervisedListDTO> GetAllEntriesSupervisors();
    }
}
