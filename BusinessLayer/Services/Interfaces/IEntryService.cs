﻿using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IEntryService
    {
        Task<IEnumerable<EventEntryDTO>> GetAllByEventId(int eventId);
        Task<EventEntryDTO> GetById(int id);
        Task Create(EventEntryDTO entry);
        Task Update(EventEntryDTO entry);
        Task Delete(int id);
        Task<IEnumerable<EventEntryDTO>> GetAllByUserId(int userId);
    }
}