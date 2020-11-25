using AutoMapper;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer.Entities;
using System.Linq;

namespace clubIS.BusinessLayer.Services
{
    public class EventService : IEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EventService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        }

        public async Task Create(EventEditDTO e)
        {
            Event entity = _mapper.Map<Event>(e);
            await _unitOfWork.Events.Add(entity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Events.Remove(await _unitOfWork.Events.GetByIdWithAllIncluded(id));
        }

        public async Task<IEnumerable<EventListDTO>> GetAllWithEntryInfo(int userId)
        {
            var entries = await _unitOfWork.Entry.GetAllByUserId(userId);
            var events = _mapper.Map<IEnumerable<EventListDTO>>(await _unitOfWork.Events.GetAllWithAllIncluded());
            foreach(var e in events) 
            {
                var entry = entries.SingleOrDefault(entry => entry.EventId == e.Id);
                if (entry != null)
                {
                    e.EntryInfo = _mapper.Map<EventEntryBasicInfoDTO>(entry);
                }
            }
            return events;
        }

        public async Task<EventEditDTO> GetById(int id)
        {
            return _mapper.Map<EventEditDTO>(await _unitOfWork.Events.GetByIdWithAllIncluded(id));
        }

        public async Task Update(EventEditDTO e)
        {
            var entity = await _unitOfWork.Events.GetByIdWithAllIncluded(e.Id);
            _mapper.Map(e, entity);
        }
    }
}
