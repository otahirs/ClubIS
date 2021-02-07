using Autofac.Extras.Moq;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.TestSamples;
using ClubIS.DataAccessLayer.Repositories;
using MockQueryable.Moq;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClubIS.DataAccessLayer.Tests
{
    public class UserRepositoryTest
    {
        [Fact]
        public async Task TestGetFinanceSupervisoredAsync()
        {
            using (AutoMock mock = AutoMock.GetLoose())
            {
                Mock<Microsoft.EntityFrameworkCore.DbSet<User>> mockDbSet = UsersTestDBSample.GetMockUsers().AsQueryable().BuildMockDbSet();
                Mock<DataContext> mockContext = new Mock<DataContext>();
                mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);

                UserRepository userRepository = new UserRepository(mockContext.Object);
                System.Collections.Generic.IEnumerable<User> matejFinanceSupervisored = await userRepository.GetFinanceSupervisored(1);
                System.Collections.Generic.IEnumerable<User> katkaFinanceSupervisored = await userRepository.GetFinanceSupervisored(2);

                Assert.True(matejFinanceSupervisored.ToList().Count == 1);
                Assert.True(matejFinanceSupervisored.ToList().First().Id == 2);
                Assert.True(katkaFinanceSupervisored.ToList().Count == 0);
            }
        }
    }
}
