﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IEntryFacade : IDisposable
    {
        Task<IEnumerable<EventEntryListDTO>> GetAllByEventId(int eventId);
        Task<EventEntryListDTO> GetById(int id);
        Task Create(EventEntryEditDTO entry);
        Task Update(EventEntryEditDTO entry);
        Task Delete(int id);
    }
}
