using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
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

        public Task Create(EventEntryPostDTO entry)
        {
            return _unitOfWork.Entry.Add(_mapper.Map<EventEntry>(entry));
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Entry.Remove(await _unitOfWork.Entry.GetById(id));
        }

        public async Task Update(EventEntryPostDTO entry)
        {
            var entryEntity = await _unitOfWork.Entry.GetById(entry.Id);
            _mapper.Map(entry, entryEntity);
        }

        public async Task<EventEntryListDTO> GetById(int id)
        {
            return _mapper.Map<EventEntryListDTO>(await _unitOfWork.Entry.GetById(id));
        }

        public async Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId)
        {
            var list = await _unitOfWork.Entry.GetAllByEventId(eventId);
            return _mapper.Map<IEnumerable<EventEntryListDTO>>(list);
        }

    }
}
