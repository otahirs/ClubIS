using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(EventDTO e)
        {
            var entity = _mapper.Map<Event>(e);
            await _unitOfWork.Events.Add(entity);
        }

        public async Task<EventDTO> GetById(int id)
        {
            return _mapper.Map<EventDTO>(await _unitOfWork.Events.GetById(id));
        }

        public async Task Update(EventDTO e)
        {
            var entity = await _unitOfWork.Events.GetById(e.Id);
            _mapper.Map(e, entity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Events.Remove(await _unitOfWork.Events.GetById(id));
        }

        public async Task<IEnumerable<EventListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<EventListDTO>>(await _unitOfWork.Events.GetAll());
        }

        public async Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId)
        {
            var entries = await _unitOfWork.Entry.GetAllByUserId(userId);
            var events = await _unitOfWork.Events.GetAll();
            return events.Select(e => new EventListWithUserEntryDTO
            {
                Event = _mapper.Map<EventListDTO>(e),
                EntryInfo = _mapper.Map<EventEntryBasicInfoDTO>(entries.SingleOrDefault(entry => entry.EventId == e.Id && entry.Status != EntryStatus.Removed))
            });
        }
    }
}