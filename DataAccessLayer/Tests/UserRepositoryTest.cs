using Autofac.Extras.Moq;
using ClubIS.CoreLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using ClubIS.CoreLayer.TestSamples;
using Moq;
using ClubIS.DataAccessLayer.Repositories;
using System.Data.Entity.Infrastructure;

namespace ClubIS.DataAccessLayer.Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task TestGetFinanceSupervisoredAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                var data = UsersTestDBSample.GetMockUsers().AsQueryable();
                var mockDbSet = new Mock<DbSet<User>>();
                mockDbSet.As<IDbAsyncEnumerable<User>>()
                    .Setup(m => m.GetAsyncEnumerator())
                    .Returns(new TestDbAsyncEnumerator<User>(data.GetEnumerator()));
                mockDbSet.As<IQueryable<User>>()
                    .Setup(m => m.Provider)
                    .Returns(new TestDbAsyncQueryProvider<User>(data.Provider));
                mockDbSet.As<IQueryable<User>>().Setup(m => m.Expression).Returns(data.Expression);
                mockDbSet.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(data.ElementType);
                mockDbSet.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

                var mockContext = new Mock<DataContext>();
                mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

                var userRepository = new UserRepository(mockContext.Object);
                var matejFinanceSupervisored = await userRepository.GetFinanceSupervisored(1);
                var katkaFinanceSupervisored = await userRepository.GetFinanceSupervisored(2);

                Assert.True(matejFinanceSupervisored.ToList().Count == 0);
                Assert.True(katkaFinanceSupervisored.ToList().Count == 1);
                Assert.True(katkaFinanceSupervisored.ToList().First().Id == 1);
            }
        }
    }
}
