using clubIS.DataAccessLayer.Repositories.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.DataAccessLayer.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(DataContext context) : base(context)
        {
        }
    }
}
