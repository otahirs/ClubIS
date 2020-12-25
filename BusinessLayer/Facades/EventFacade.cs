using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Facades
{
    public class EventFacade : IEventFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventService _eventService;
        private readonly IPaymentService _paymentService;

        public EventFacade(IUnitOfWork unitOfWork, IEventService eventService, IPaymentService paymentService)
        {
            _unitOfWork = unitOfWork;
            _eventService = eventService;
            _paymentService = paymentService;
        }

        public async Task<IEnumerable<EventListWithExportStatusDTO>> GetAllWithExportStatus()
        {
            return await _eventService.GetAllWithExportStatus();
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

        public async Task<IEnumerable<EventListDTO>> GetAll()
        {
            return await _eventService.GetAll();
        }

        public async Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId)
        {
            return await _eventService.GetAllWithUserEntry(userId);
        }

        public async Task<EventEntryEditDTO> GetByIdEntryFormData(int id)
        {
            return await _eventService.GetByIdEntryFormData(id);
        }

        public async Task<IEnumerable<EventListWithTotalCostsDTO>> GetAllWithTotalCosts()
        {
            var events = await _eventService.GetAll();
            return await Task.WhenAll(events
                .Select(async e => new EventListWithTotalCostsDTO
                    {
                        Event = e,
                        TotalCosts = await _paymentService.GetEventPaymentSumByEventId(e.Id)
                    }
                ));
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
