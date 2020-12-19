using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.DTOs;

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
