using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(NewsEditDTO news)
        {
            News newsEntity = _mapper.Map<News>(news);
            await _unitOfWork.News.Add(newsEntity);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.News.Remove(await _unitOfWork.News.GetById(id));
        }

        public async Task<IEnumerable<NewsListDTO>> GetAll()
        {
            IEnumerable<News> list = await _unitOfWork.News.GetAll();
            return _mapper.Map<IEnumerable<NewsListDTO>>(list);
        }

        public async Task<NewsEditDTO> GetById(int id)
        {
            return _mapper.Map<NewsEditDTO>(await _unitOfWork.News.GetById(id));
        }

        public async Task Update(NewsEditDTO news)
        {
            News newsEntity = await _unitOfWork.News.GetById(news.Id);
            _mapper.Map(news, newsEntity);
        }
    }
}
