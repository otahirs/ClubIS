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

        public async Task<IEnumerable<User>> GetAllById(IEnumerable<int> ids)
        {
            return await _entities.Where(u => ids.Contains(u.Id)).ToListAsync();
        }
    }
}