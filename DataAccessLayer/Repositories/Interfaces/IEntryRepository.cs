using ClubIS.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IEntryRepository : IRepository<EventEntry>
    {
        Task<IEnumerable<EventEntry>> GetAllByEventId(int eventId);
        Task<IEnumerable<EventEntry>> GetAllByUserId(int userId);
    }
}
