﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services;
using ClubIS.CoreLayer.DTOs;
using FluentAssertions;
using FluentAssertions.Execution;
using Xunit;

namespace ClubIS.BusinessLayer.Tests
{
    public class NewsServiceTests
    {
        private readonly IMapper _mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();

        [Fact]
        public async Task GetById() // db seed dependant
        {
            NewsEditDTO news;
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new NewsService(uow, _mapper);
                news = await ns.GetById(1);
            }

            Assert.NotNull(news);
        }

        [Fact]
        public async Task Create()
        {
            var origNews = new NewsEditDTO
            {
                Id = 42,
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            NewsEditDTO news;
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new NewsService(uow, _mapper);
                await ns.Create(origNews);
                await uow.Save();
                news = await ns.GetById(42);
            }

            origNews.Should().BeEquivalentTo(news);
        }

        [Fact]
        public async Task Update()
        {
            var origNews = new NewsEditDTO
            {
                Id = 42,
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            NewsEditDTO news;
            var editedTitle = "Edited Title";
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new NewsService(uow, _mapper);
                await ns.Create(origNews);
                await uow.Save();
                news = await ns.GetById(42);
                news.Title = editedTitle;
                await ns.Update(news);
                await uow.Save();
                news = await ns.GetById(42);
            }

            Assert.Equal(editedTitle, news.Title);
        }

        [Fact]
        public async Task Delete()
        {
            var origNews = new NewsEditDTO
            {
                Id = 42,
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            NewsEditDTO news;
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new NewsService(uow, _mapper);
                await ns.Create(origNews);
                await uow.Save();
                await ns.Delete(origNews.Id);
                await uow.Save();
                news = await ns.GetById(42);
            }

            Assert.Null(news);
        }

        [Fact]
        public async Task GetAll() // db seed dependant
        {
            var origNews1 = new NewsEditDTO
            {
                Id = 42,
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            var origNews2 = new NewsEditDTO
            {
                Id = 43,
                UserId = 1,
                Date = DateTime.Now,
                Title = "Super novinka!",
                Text = "V sobotu 30. února rozdáváme 5kg kyblíky nutely zdarma :O "
            };
            List<NewsListDTO> news;
            using (var uow = TestUoWFactory.Create())
            {
                var ns = new NewsService(uow, _mapper);
                await ns.Create(origNews1);
                await ns.Create(origNews2);
                await uow.Save();
                news = (await ns.GetAll()).ToList();
            }

            using (new AssertionScope())
            {
                news.Count.Should().BeGreaterThan(1);
                var news1 = news.First(n => n.Id == 42);
                news1.Date.Should().Be(origNews1.Date);
                news1.UserId.Should().Be(origNews1.UserId);
                news1.Title.Should().Be(origNews1.Title);
                news1.Text.Should().Be(origNews1.Text);
                news1.UserName.Should().NotBeNullOrEmpty();
            }
        }
    }
}