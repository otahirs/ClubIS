using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.Entities;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetByIdWithAllIncluded(int id);
        Task<IEnumerable<Event>> GetAllWithAllIncluded();
    }
}
