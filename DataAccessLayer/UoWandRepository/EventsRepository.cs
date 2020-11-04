using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.UoWandRepository;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EventsRepository : GenericRepository<Event>, IEventsRepository
{
    public EventsRepository(DataContext context) : base(context)
    {
        
    }
    public async Task<IEnumerable<Event>> GetCancelled()
    {
        return await _context.Events.Where(e => e.EventState == EventState.Canceled).ToListAsync();
    }

}
