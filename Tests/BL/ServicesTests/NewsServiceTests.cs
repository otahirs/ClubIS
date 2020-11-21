using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using AutoMapper;
using clubIS.BusinessLayer.MapperConfig;
using FluentAssertions.Execution;
using FluentAssertions;

namespace clubIS.BusinessLayer.Tests.ServicesTests
{
    public class NewsServiceTests
    {
        //private readonly IMapper _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));

        [Fact]
        public async Task Basic()
        {
            var origNews = new NewsEditDTO()
            {
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            NewsListDTO news;
            using (var uow = TestUoWFactory.Create())
            {
                var ps = new NewsService(uow);
                await ps.Create(origNews);
                await uow.Save();
                news = (await ps.GetAll()).Last();
            }

            using (new AssertionScope())
            {
                news.Date.Should().Be(origNews.Date);
                news.Title.Should().Be(origNews.Title);
                news.Text.Should().Be(origNews.Text);
                news.UserName.Should().NotBeNullOrEmpty();
            }
        }

    }
}
