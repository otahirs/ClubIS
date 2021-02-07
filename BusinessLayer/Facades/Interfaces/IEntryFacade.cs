using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEntryFacade : IDisposable
    {
        Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId);
        Task<EventEntryListDTO> GetById(int id);
        Task Create(EventEntryEditDTO entry);
        Task Update(EventEntryEditDTO entry);
        Task Delete(int id);
    }
}
