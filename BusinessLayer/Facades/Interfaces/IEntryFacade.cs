using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEntryFacade : IDisposable
    {
        Task<IEnumerable<EventEntryDTO>> GetAllByEventId(int eventId);
        Task<EventEntryDTO> GetById(int id);
        Task Create(EventEntryDTO entry);
        Task Update(EventEntryDTO entry);
        Task Delete(int id);
    }
}