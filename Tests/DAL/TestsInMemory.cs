using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Xunit;

namespace clubIS.DataAccessLayer.Tests
{
    public class TestsInMemory
    {
        private readonly Func<TestClubContext> _createContext = () =>
        {
            var context = new TestClubContext();
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
                context.News.Add(new News()
                {
                    UserId = 1,
                    Date = new DateTime(2020, 10, 24),
                    Title = "Hello",
                    IsPublic = false
                });
                context.SaveChanges();
                var item = context.News.FirstOrDefault(e => e.Id == id);
                actualDate = item.Date;
            }

            Assert.Equal(expectedDate, actualDate);
        }
    }
}
