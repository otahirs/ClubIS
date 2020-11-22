using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IEntryService
    {
        Task<IEnumerable<EventEntryListDTO>> GetAllByEventId();
        Task Create(EventEntryEditDTO entry);
        Task Update(EventEntryEditDTO entry);
        Task Delete(int id);
    }
}
