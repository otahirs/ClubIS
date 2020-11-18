using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface INewsService
    {
        public Task Create(NewsEditDTO news);
        public Task<NewsEditDTO> GetById(int id);
        public Task<IEnumerable<NewsListDTO>> GetAll();
        public Task Update(NewsEditDTO news);
        public Task Delete(int id);
    }
}
