using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.DataAccessLayer.Entities;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IEntryRepository : IRepository<EventEntry>
    {
        Task<IEnumerable<EventEntry>> GetAllWithAllIncluded();
    }
}
