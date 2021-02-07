﻿using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades
{
    public class EntryFacade : IEntryFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEntryService _entryService;

        public EntryFacade(IUnitOfWork unitOfWork, IEntryService entryService)
        {
            _unitOfWork = unitOfWork;
            _entryService = entryService;
        }

        public async Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId)
        {
            return await _entryService.GetAllByEventId(eventId);
        }


        public async Task<EventEntryListDTO> GetById(int id)
        {
            return await _entryService.GetById(id);
        }

        public async Task Create(EventEntryEditDTO entry)
        {
            await _entryService.Create(entry);
            await _unitOfWork.Save();
        }

        public async Task Update(EventEntryEditDTO entry)
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
