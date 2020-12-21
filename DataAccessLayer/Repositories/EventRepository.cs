using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
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
