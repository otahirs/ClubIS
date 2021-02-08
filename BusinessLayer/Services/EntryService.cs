using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services
{
    public class EntryService : IEntryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EntryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(EventEntryEditDTO entry)
        {
            EventEntry entryEntity = _mapper.Map<EventEntry>(entry);
            entryEntity.EnteredStages = _mapper.Map<ISet<EventStage>>(
                    await _unitOfWork.Stages.GetAllById(entry.EnteredStages.Select(u => u.Id))
                );

           await _unitOfWork.Entry.Add(entryEntity);
        }

        public async Task Delete(int id)
        {
            EventEntry entryEntity = await _unitOfWork.Entry.GetById(id);
            entryEntity.EnteredStages.Clear();
            _unitOfWork.Entry.Remove(entryEntity);
        }

        public async Task Update(EventEntryEditDTO entry)
        {
            EventEntry entryEntity = await _unitOfWork.Entry.GetById(entry.Id);
            entryEntity.EnteredStages.Clear();
            _mapper.Map(entry, entryEntity);
            entryEntity.EnteredStages = _mapper.Map<ISet<EventStage>>(
                    await _unitOfWork.Stages.GetAllById(entry.EnteredStages.Select(u => u.Id))
                );

        }

        public async Task<EventEntryListDTO> GetById(int id)
        {
            return _mapper.Map<EventEntryListDTO>(await _unitOfWork.Entry.GetById(id));
        }

        public async Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId)
        {
            IEnumerable<EventEntry> list = await _unitOfWork.Entry.GetAllByEventId(eventId);
            return _mapper.Map<IEnumerable<EventEntryListDTO>>(list);
        }

    }
}
