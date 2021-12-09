using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<IEnumerable<User>> GetAllById(IEnumerable<int> ids);
    }
}