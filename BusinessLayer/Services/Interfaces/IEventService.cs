using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IEventService
    {
        Task Create(EventEditDTO e);
        Task<IEnumerable<EventListDTO>> GetAllWithEntryInfo(int userId);
        Task<EventEditDTO> GetById(int id);
        Task Update(EventEditDTO e);
        Task Delete(int id);
    }
}
