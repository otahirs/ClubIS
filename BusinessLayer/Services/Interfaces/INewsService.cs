using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
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