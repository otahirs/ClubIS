using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class NewsRepository : Repository<News>, INewsRepository
    {
        public NewsRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<News>> GetAllIncludeUser()
        {
            return await _entities
                .Include(n => n.User)
                .ToListAsync();
        }
    }
}
