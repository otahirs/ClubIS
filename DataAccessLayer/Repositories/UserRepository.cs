using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {
        }

        public async Task<User> GetEntriesSupervisorsById(int id)
        {
            return await _entities
                .Include(u => u.SiCards)
                .Include(u => u.EntriesSupervisedUsers)
                    .ThenInclude(u => u.User)
                        .ThenInclude(u => u.SiCards)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<IEnumerable<User>> GetFinanceSupervisored(int userId)
        {
            return await _entities.Where(u => u.FinanceSupervisorId == userId).ToListAsync();
        }
    }
}
