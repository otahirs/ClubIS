using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using AutoMapper;
using ClubIS.BusinessLayer.Services;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.TestSamples;
using ClubIS.DataAccessLayer;
using Moq;
using Xunit;

namespace ClubIS.BusinessLayer.Tests
{
    public class UserServiceUnitTest
    {
        private readonly IMapper _mapper = new MapperConfiguration(c => c.AddProfile<AutoMapperProfile>()).CreateMapper();

        [Fact]
        public async Task TestGetAllEntriesSupervisorsByIdAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUnitOfWork>().Setup(x => x.Users.GetById(It.IsAny<int>())).Returns<int>(i => UsersTestDBSample.GetMockUserById(i));

                mock.Mock<IMapper>().Setup(x => x.Map<IEnumerable<EntryUserListDTO>>(It.IsAny<IEnumerable<User>>())).Returns<IEnumerable<User>>(i => _mapper.Map<IEnumerable<EntryUserListDTO>>(i));

                var userService = mock.Create<UserService>();
                var result1 = await userService.GetUsersUnderEntrySupervision(1);
                var result2 = await userService.GetUsersUnderEntrySupervision(2);

                Assert.True(result1.Count() == 1);
                Assert.True(result1.First().Id == 2);
                Assert.True(result2.Count() == 0);
            }
        }

        [Fact]
        public async Task TestGetUserSupervisionsAsync()
        {
            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IUnitOfWork>().Setup(x => x.Users.GetById(It.IsAny<int>())).Returns<int>(i => UsersTestDBSample.GetMockUserById(i));

                mock.Mock<IMapper>().Setup(x => x.Map<ISet<UserListDTO>>(It.IsAny<IEnumerable<User>>())).Returns<IEnumerable<User>>(i => _mapper.Map<ISet<UserListDTO>>(i));

                mock.Mock<IMapper>().Setup(x => x.Map<UserListDTO>(It.IsAny<User>())).Returns<User>(i => _mapper.Map<UserListDTO>(i));

                var userService = mock.Create<UserService>();
                var result1 = await userService.GetUserSupervisions(1);
                var result2 = await userService.GetUserSupervisions(2);

                Assert.True(result1.EntriesSupervisors.ToList().Count == 0);
                Assert.True(result1.EntriesSupervisedUsers.ToList().Count == 1);
                Assert.True(result1.EntriesSupervisedUsers.First().Id == 2);
                Assert.True(result1.FinanceSupervisors.ToList().Count == 0);
                Assert.True(result1.FinanceSupervisedUsers.ToList().Count == 1);
                Assert.True(result1.FinanceSupervisedUsers.First().Id == 2);

                Assert.True(result2.EntriesSupervisors.ToList().Count == 1);
                Assert.True(result2.EntriesSupervisors.First().Id == 1);
                Assert.True(result2.EntriesSupervisedUsers.ToList().Count == 0);
                Assert.True(result2.FinanceSupervisors.ToList().Count == 1);
                Assert.True(result2.FinanceSupervisors.First().Id == 1);
                Assert.True(result2.FinanceSupervisedUsers.ToList().Count == 0);
            }
        }
    }
}