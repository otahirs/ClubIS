using clubIS.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using clubIS.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace clubIS.DataAccessLayer.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Event>> GetAllWithAllIncluded()
        {
            return await _entities
                .Include(e => e.Deadlines)
                .Include(e => e.EventStages)
                .ToListAsync();
        }

        public async Task<Event> GetByIdWithAllIncluded(int id)
        {
            return await _entities
                .Include(e => e.Deadlines)
                .Include(e => e.EventStages)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
