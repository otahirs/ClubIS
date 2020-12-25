using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task Create(EventEditDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<EventEntryEditDTO> GetByIdEntryFormData(int id);
        Task<IEnumerable<EventListWithExportStatusDTO>> GetAllWithExportStatus();
        Task<EventEditDTO> GetById(int id);
        Task Update(EventEditDTO e);
        Task Delete(int id);
    }
}
