using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface INewsService
    {
        Task Create(NewsEditDTO news);
        Task<NewsEditDTO> GetById(int id);
        Task<IEnumerable<NewsListDTO>> GetAll();
        Task Update(NewsEditDTO news);
        Task Delete(int id);
    }
}
