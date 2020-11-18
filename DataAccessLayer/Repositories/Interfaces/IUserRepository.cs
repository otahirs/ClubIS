using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetNameAndRegNumOnlyByAccountId(int id);
        Task<IEnumerable<User>> GetAllNameAndRegNumOnly();
        Task<Tuple<string, string>> GetNameById(int id);
        Task<Tuple<string, string>> GetNameByAccountId(int accountId);
    }
}
