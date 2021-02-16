using System.Collections.Generic;
using System.Linq;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public EntryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(EventEntryDTO entry)
        {
            var entryEntity = _mapper.Map<EventEntry>(entry);
            entryEntity.EnteredStages = _mapper.Map<ISet<EventStage>>(await _unitOfWork.Stages.GetAllById(entry.EnteredStages.Select(u => u.Id)));

            await _unitOfWork.Entry.Add(entryEntity);
        }

        public async Task Delete(int id)
        {
            var entryEntity = await _unitOfWork.Entry.GetById(id);
            entryEntity.EnteredStages.Clear();
            _unitOfWork.Entry.Remove(entryEntity);
        }

        public async Task Update(EventEntryDTO entry)
        {
            var entryEntity = await _unitOfWork.Entry.GetById(entry.Id);
            entryEntity.EnteredStages.Clear();
            _mapper.Map(entry, entryEntity);
            entryEntity.EnteredStages = _mapper.Map<ISet<EventStage>>(await _unitOfWork.Stages.GetAllById(entry.EnteredStages.Select(u => u.Id)));
        }

        public async Task<EventEntryDTO> GetById(int id)
        {
            return _mapper.Map<EventEntryDTO>(await _unitOfWork.Entry.GetById(id));
        }

        public async Task<IEnumerable<EventEntryDTO>> GetAllByEventId(int eventId)
        {
            var list = await _unitOfWork.Entry.GetAllByEventId(eventId);
            return _mapper.Map<IEnumerable<EventEntryDTO>>(list);
        }

        public async Task<IEnumerable<EventEntryDTO>> GetAllByUserId(int userId)
        {
            var list = await _unitOfWork.Entry.GetAllByUserId(userId);
            return _mapper.Map<IEnumerable<EventEntryDTO>>(list);
        }
    }
}