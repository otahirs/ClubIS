using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories
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
