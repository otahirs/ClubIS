using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IEntryRepository : IRepository<EventEntry>
    {
        Task<EventEntry> GetByIdWithAllIncluded(int id);
        Task<IEnumerable<EventEntry>> GetAllWithAllIncluded();
        Task<IEnumerable<EventEntry>> GetAllByEventId(int eventId);
        Task<IEnumerable<EventEntry>> GetAllByUserId(int userId);
    }
}
