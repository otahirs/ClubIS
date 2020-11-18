using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IEventService
    {
        public Task Create(EventEditDTO e);
        public Task<IEnumerable<EventListDTO>> GetAll();
        public Task<EventDetailDTO> GetById(int id);
        public Task Update(EventEditDTO e);
        public void Delete(int id);
    }
}
