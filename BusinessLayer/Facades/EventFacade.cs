using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Facades.Interfaces;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;

namespace clubIS.BusinessLayer.Facades
{
    public class EventFacade : IEventFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _eventService;

        public EventFacade(IUnitOfWork unitOfWork, IEventService eventService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
        }
        public async Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithEntryInfo(int userId)
        {
            return await _eventService.GetAllWithEntryInfo(userId);
        }

        public async Task<EventEditDTO> GetById(int id)
        {
            return await _eventService.GetById(id);
        }

        public async Task Create(EventEditDTO e)
        {
            await _eventService.Create(e);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await _eventService.Delete(id);
            await _unitOfWork.Save();
        }

        public async Task Update(EventEditDTO e)
        {
            await _eventService.Update(e);
            await _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
