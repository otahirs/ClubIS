using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IEntryService
    {
        Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId);
        Task<EventEntryListDTO> GetById(int id);
        Task Create(EventEntryPostDTO entry);
        Task Update(EventEntryPostDTO entry);
        Task Delete(int id);
    }
}
