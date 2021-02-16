using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Facades
{
    public class NewsFacade : INewsFacade
    {
        private readonly INewsService _newsService;
        private readonly IUnitOfWork _unitOfWork;

        public NewsFacade(IUnitOfWork unitOfWork, INewsService newsService)
        {
            _unitOfWork = unitOfWork;
            _newsService = newsService;
        }

        public async Task Create(NewsEditDTO news)
        {
            await _newsService.Create(news);
            await _unitOfWork.Save();
        }

        public async Task Update(NewsEditDTO news)
        {
            await _newsService.Update(news);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await _newsService.Delete(id);
            await _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<NewsListDTO>> GetAll()
        {
            return await _newsService.GetAll();
        }

        public async Task<NewsEditDTO> GetById(int id)
        {
            return await _newsService.GetById(id);
        }
    }
}