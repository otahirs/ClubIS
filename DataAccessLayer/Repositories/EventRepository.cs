using clubIS.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using clubIS.DataAccessLayer.Entities;

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
                .Include(e => e.ClassOptions)
                .ToListAsync();
        }

        public async Task<Event> GetByIdWithAllIncluded(int id)
        {
            return await _entities
                .Include(e => e.Deadlines)
                .Include(e => e.EventStages)
                .Include(e => e.ClassOptions)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
