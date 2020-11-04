using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.UoWandRepository
{
    public interface IEventsRepository : IGenericRepository<Event>
    {
        Task<IEnumerable<Event>> GetCancelled();
    }
}
