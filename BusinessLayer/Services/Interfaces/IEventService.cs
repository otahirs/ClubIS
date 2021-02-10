using ClubIS.CoreLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task Create(EventDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<EventDTO> GetById(int id);
        Task Update(EventDTO e);
        Task Delete(int id);
    }
}
