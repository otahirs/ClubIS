using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IEntryService
    {
        Task<IEnumerable<EventEntriesListDTO>> GetAllByEventId();


    }
}
