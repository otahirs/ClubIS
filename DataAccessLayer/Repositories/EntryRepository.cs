﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class EntryRepository : Repository<EventEntry>, IEntryRepository
    {
        public EntryRepository(DataContext context) : base(context)
        {
        }

        public async Task<IEnumerable<EventEntry>> GetAllByEventId(int eventId)
        {
            return await _entities.Where(e => e.EventId == eventId).Include(e => e.EnteredStages).Include(e => e.User).ToListAsync();
        }


        public async Task<IEnumerable<EventEntry>> GetAllByUserId(int userId)
        {
            return await _entities.Where(e => e.UserId == userId).ToListAsync();
        }
    }
}