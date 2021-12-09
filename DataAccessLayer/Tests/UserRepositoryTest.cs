using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.TestSamples;
using ClubIS.DataAccessLayer.Repositories;
using MockQueryable.Moq;
using Moq;
using Xunit;

namespace ClubIS.DataAccessLayer.Tests
{
    public class UserRepositoryTest
    {
        // [Fact]
        // public async Task TestGetFinanceSupervisoredAsync()
        // {
        //     using (var mock = AutoMock.GetLoose())
        //     {
        //         var mockDbSet = UsersTestDBSample.GetMockUsers().AsQueryable().BuildMockDbSet();
        //         var mockContext = new Mock<DataContext>();
        //         mockContext.Setup(c => c.Set<User>()).Returns(mockDbSet.Object);
        //
        //         var userRepository = new UserRepository(mockContext.Object);
        //         var matejFinanceSupervisored = await userRepository.GetFinanceSupervisored(1);
        //         var katkaFinanceSupervisored = await userRepository.GetFinanceSupervisored(2);
        //
        //         Assert.True(matejFinanceSupervisored.ToList().Count == 1);
        //         Assert.True(matejFinanceSupervisored.ToList().First().Id == 2);
        //         Assert.True(katkaFinanceSupervisored.ToList().Count == 0);
        //     }
        // }
    }
}