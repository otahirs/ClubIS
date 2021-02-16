using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Facades
{
    public class EntryFacade : IEntryFacade
    {
        private readonly IEntryService _entryService;
        private readonly IUnitOfWork _unitOfWork;

        public EntryFacade(IUnitOfWork unitOfWork, IEntryService entryService)
        {
            _unitOfWork = unitOfWork;
            _entryService = entryService;
        }

        public async Task<IEnumerable<EventEntryDTO>> GetAllByEventId(int eventId)
        {
            return await _entryService.GetAllByEventId(eventId);
        }


        public async Task<EventEntryDTO> GetById(int id)
        {
            return await _entryService.GetById(id);
        }

        public async Task Create(EventEntryDTO entry)
        {
            await _entryService.Create(entry);
            await _unitOfWork.Save();
        }

        public async Task Update(EventEntryDTO entry)
        {
            await _entryService.Update(entry);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await _entryService.Delete(id);
            await _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}