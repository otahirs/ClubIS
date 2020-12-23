﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
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

        public async Task<EventEditDTO> GetById(int id)
        {
            return _mapper.Map<EventEditDTO>(await _unitOfWork.Events.GetByIdWithAllIncluded(id));
        }

        public async Task Update(EventEditDTO e)
        {
            var entity = await _unitOfWork.Events.GetByIdWithAllIncluded(e.Id);
            _mapper.Map(e, entity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Events.Remove(await _unitOfWork.Events.GetByIdWithAllIncluded(id));
        }

        public async Task<IEnumerable<EventListDTO>> GetAll()
        {
            return _mapper.Map<IEnumerable<EventListDTO>>(await _unitOfWork.Events.GetAllWithAllIncluded());
        }

        public async Task<IEnumerable<EventListWithUserEntryDTO>> GetAllWithUserEntry(int userId)
        {
            var entries = await _unitOfWork.Entry.GetAllByUserId(userId);
            var events = await _unitOfWork.Events.GetAllWithAllIncluded();
            return events.Select(e => new EventListWithUserEntryDTO()
            {
                Event = _mapper.Map<EventListDTO>(e),
                EntryInfo = _mapper.Map<EventEntryBasicInfoDTO>(entries.SingleOrDefault(entry => entry.EventId == e.Id))
            });
        }

        public async Task<EventEditWithUserEntryDTO> GetByIdWithUserEntry(int id, int userId)
        {
            var entries = await _unitOfWork.Entry.GetAllByUserId(userId);
            var e = await _unitOfWork.Events.GetByIdWithAllIncluded(id);
            return new EventEditWithUserEntryDTO()
            {
                Event = _mapper.Map<EventEntryEditDTO>(e),
                EntryInfo = _mapper.Map<EventEntryBasicInfoDTO>(entries.SingleOrDefault(entry => entry.EventId == e.Id))
            };
        }

        public async Task<IEnumerable<EventListWithExportStatusDTO>> GetAllWithExportStatus()
        {
            var events = await _unitOfWork.Events.GetAllWithAllIncluded();
            return events.Select(e => new EventListWithExportStatusDTO()
            {
                Event = _mapper.Map<EventListDTO>(e),
                ExportStatus = 0 // TODO
            });
        }
    }
}
