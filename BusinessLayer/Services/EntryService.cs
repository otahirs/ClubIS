using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using clubIS.DataAccessLayer.Entities;

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
            _unitOfWork.Entry.Remove(await _unitOfWork.Entry.GetById(id));
        }

        public async Task Update(EventEntryEditDTO entry)
        {
            var entryEntity = await _unitOfWork.Entry.GetById(entry.Id);
            _mapper.Map(entry, entryEntity);
        }

        public async Task<IEnumerable<EventEntriesListDTO>> GetAllByEventId()
        {
            var list = await _unitOfWork.Entry.GetAllWithAllIncluded();
            return _mapper.Map<IEnumerable<EventEntriesListDTO>>(list);
        }
    }
}
