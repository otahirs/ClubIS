using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace clubIS.DataAccessLayer.Repositories
{
    public class EntryRepository : Repository<EventEntry>, IEntryRepository
    {
        public EntryRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventEntry>> GetAllWithAllIncluded()
        {
            return await _entities
                .Include(e => e.EnteredStages)
                .ToListAsync();
        }
    }
}
