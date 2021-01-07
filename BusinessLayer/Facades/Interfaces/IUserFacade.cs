using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IUserFacade : IDisposable
    {
        Task Create(UserEditDTO e);
        Task<IEnumerable<UserListDTO>> GetAll();
        Task<UserDetailDTO> GetById(int id);
        Task Update(UserEditDTO e);
        Task Update(MemberUserEditDTO e);
        Task Delete(int id);
        Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors();
        Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id);
    }
}
