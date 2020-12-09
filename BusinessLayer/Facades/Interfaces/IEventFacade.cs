using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;

namespace clubIS.BusinessLayer.Facades.Interfaces
{
    interface IEventFacade : IDisposable
    {
        Task Create(EventEditDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<IEnumerable<EventListWithTotalCostsDTO>> GetAllWithTotalCosts();
        Task<IEnumerable<EventListWithExportStatusDTO>> GetAllWithExportStatus();
        Task<EventEditDTO> GetById(int id);
        Task Update(EventEditDTO e);
        Task Delete(int id);
    }
}
