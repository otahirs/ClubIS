﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Facades.Interfaces;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;

namespace clubIS.BusinessLayer.Facades
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

        public async Task<EventEntryEditDTO> GetById(int id)
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