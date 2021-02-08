using ClubIS.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllById(IEnumerable<int> ids);
        Task<User> GetEntriesSupervisorsById(int id);
        Task<IEnumerable<User>> GetFinanceSupervisored(int userId);
        public void RemoveFinanceSupervisor(int supervisorUserId);
    }
}
