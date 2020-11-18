using AutoMapper;
using clubIS.BusinessLayer;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
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
            var list = await _unitOfWork.News.GetAll();
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
