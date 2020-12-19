using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.CoreLayer.DTOs;
using clubIS.CoreLayer.Entities;
using clubIS.DataAccessLayer;

namespace clubIS.BusinessLayer.Services
{
    public class EntryService : IEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EntryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        }

        public Task Create(EventEntryEditDTO entry)
        {
            return _unitOfWork.Entry.Add(_mapper.Map<EventEntry>(entry));
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Entry.Remove(await _unitOfWork.Entry.GetByIdWithAllIncluded(id));
        }

        public async Task Update(EventEntryEditDTO entry)
        {
            var entryEntity = await _unitOfWork.Entry.GetByIdWithAllIncluded(entry.Id);
            _mapper.Map(entry, entryEntity);
        }

        public async Task<EventEntryEditDTO> GetById(int id)
        {
            return _mapper.Map<EventEntryEditDTO>(await _unitOfWork.Entry.GetByIdWithAllIncluded(id));
        }

        public async Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId)
        {
            var list = await _unitOfWork.Entry.GetAllByEventId(eventId);
            return _mapper.Map<IEnumerable<EventEntryListDTO>>(list);
        }
    }
}
