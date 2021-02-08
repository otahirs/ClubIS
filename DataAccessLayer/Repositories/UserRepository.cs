using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetAllById(IEnumerable<int> ids)
        {
            return await _entities.Where(u => ids.Contains(u.Id)).ToListAsync();
        }

        public async Task<User> GetEntriesSupervisorsById(int id)
        {
            return await _entities
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<IEnumerable<User>> GetFinanceSupervisored(int userId)
        {
            return await _entities.Where(u => u.FinanceSupervisorId == userId).ToListAsync();
        }

        public void RemoveFinanceSupervisor(int supervisorUserId)
        {
            IQueryable<User> users = _entities.Where(u => u.FinanceSupervisorId == supervisorUserId);
            foreach (User u in users)
            {
                u.FinanceSupervisorId = null;
            }
        }
    }
}
