using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IUserFacade : IDisposable
    {
        Task Create(UserDTO e);
        Task<IEnumerable<UserListDTO>> GetAll();
        Task<UserDTO> GetById(int id);
        Task Update(UserDTO e);
        Task Update(MemberUserEditDTO e);
        Task UpdateSupervisions(UserSupervisionsDTO user);
        Task Delete(int id);
        Task<IEnumerable<UserEntriesSupervisedListDTO>> GetAllEntriesSupervisors();
        Task<UserEntryListDTO> GetAllEntriesSupervisorsById(int id);

        Task<UserSupervisionsDTO> GetUserSupervisions(int id);
    }
}
