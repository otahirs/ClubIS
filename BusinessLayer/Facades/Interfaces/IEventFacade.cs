using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEventFacade : IDisposable
    {
        Task Create(EventDTO e);
        Task<IEnumerable<EventListDTO>> GetAll();
        Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId);
        Task<IEnumerable<EventListWithTotalCostsDTO>> GetAllWithTotalCosts();
        Task<EventDTO> GetById(int id);
        Task Update(EventDTO e);
        Task Delete(int id);
    }
}
