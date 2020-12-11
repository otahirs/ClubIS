using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;

namespace clubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEntryFacade : IDisposable
    {
        Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId);
        Task<EventEntryEditDTO> GetById(int id);
        Task Create(EventEntryEditDTO entry);
        Task Update(EventEntryEditDTO entry);
        Task Delete(int id);
    }
}
