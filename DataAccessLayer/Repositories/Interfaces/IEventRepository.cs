using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IEventRepository : IRepository<Event>
    {
        Task<Event> GetByIdWithAllIncluded(int id);
    }
}
