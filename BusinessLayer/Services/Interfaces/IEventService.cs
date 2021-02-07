using ClubIS.CoreLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task Create(EventEditDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<EventEditDTO> GetById(int id);
        Task Update(EventEditDTO e);
        Task Delete(int id);
    }
}
