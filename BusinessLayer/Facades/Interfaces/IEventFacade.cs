using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEventFacade : IDisposable
    {
        Task Create(EventEditDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<EventEditWithUserEntryDTO> GetByIdWithUserEntry(int id, int userId);
        Task<IEnumerable<EventListWithTotalCostsDTO>> GetAllWithTotalCosts();
        Task<IEnumerable<EventListWithExportStatusDTO>> GetAllWithExportStatus();
        Task<EventEditDTO> GetById(int id);
        Task Update(EventEditDTO e);
        Task Delete(int id);
    }
}
