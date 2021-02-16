using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
{
    public class NewsService : INewsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(NewsEditDTO news)
        {
            var newsEntity = _mapper.Map<News>(news);
            await _unitOfWork.News.Add(newsEntity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.News.Remove(await _unitOfWork.News.GetById(id));
        }

        public async Task<IEnumerable<NewsListDTO>> GetAll()
        {
            var list = await _unitOfWork.News.GetAll();
            return _mapper.Map<IEnumerable<NewsListDTO>>(list);
        }

        public async Task<NewsEditDTO> GetById(int id)
        {
            return _mapper.Map<NewsEditDTO>(await _unitOfWork.News.GetById(id));
        }

        public async Task Update(NewsEditDTO news)
        {
            var newsEntity = await _unitOfWork.News.GetById(news.Id);
            _mapper.Map(news, newsEntity);
        }
    }
}