using ClubIS.CoreLayer.Entities;
using System;
using System.Linq;
using Xunit;

namespace ClubIS.DataAccessLayer.Tests
{
    public class TestsInMemory
    {
        private readonly Func<TestClubContext> _createContext = () =>
        {
            TestClubContext context = new TestClubContext();
            context.Database.EnsureCreated();
            return context;
        };

        [Fact]
        public void GetReturnsCorrectNews()
        {
            DateTime actualDate;
            DateTime expectedDate = new DateTime(2020, 10, 24);
            const int id = 2;
            using (TestClubContext context = _createContext())
            {
                context.News.Add(new News()
                {
                    UserId = 1,
                    Date = new DateTime(2020, 10, 24),
                    Title = "Hello",
                });
                context.SaveChanges();
                News item = context.News.FirstOrDefault(e => e.Id == id);
                actualDate = item.Date;
            }

            Assert.Equal(expectedDate, actualDate);
        }
    }
}
