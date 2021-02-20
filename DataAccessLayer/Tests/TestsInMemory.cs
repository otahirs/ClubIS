using System;
using System.Linq;
using ClubIS.CoreLayer.Entities;
using Xunit;

namespace ClubIS.DataAccessLayer.Tests
{
    public class TestsInMemory
    {
        private readonly Func<DataContext> _createContext = () =>
        {
            var context = new DataContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
            return context;
        };

        [Fact]
        public void GetReturnsCorrectNews()
        {
            DateTime actualDate;
            var expectedDate = new DateTime(2020, 10, 24);
            const int id = 2;
            using (var context = _createContext())
            {
                context.News.Add(new News
                {
                    UserId = 1,
                    Date = new DateTime(2020, 10, 24),
                    Title = "Hello"
                });
                context.SaveChanges();
                var item = context.News.FirstOrDefault(e => e.Id == id);
                actualDate = item.Date;
            }

            Assert.Equal(expectedDate, actualDate);
        }
    }
}