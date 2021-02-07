using Autofac.Extras.Moq;
using AutoMapper;
using ClubIS.BusinessLayer.Services;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.TestSamples;
using ClubIS.DataAccessLayer;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace ClubIS.BusinessLayer.Tests
{
    public class UserServiceUnitTest
    {
        private readonly IMapper _mapper = new MapperConfiguration(c =>
          c.AddProfile<AutoMapperProfile>()).CreateMapper();

        [Fact]
        public async Task TestGetAllEntriesSupervisorsByIdAsync()
        {
            using (AutoMock mock = AutoMock.GetLoose())
            {
                mock.Mock<IUnitOfWork>()
                   .Setup(x => x.Users.GetEntriesSupervisorsById(It.IsAny<int>()))
                   .Returns<int>(i => UsersTestDBSample.GetMockUserById(i));

                mock.Mock<IMapper>()
                    .Setup(x => x.Map<IEnumerable<UserEntryEditDTO>>(It.IsAny<IEnumerable<User>>()))
                    .Returns<IEnumerable<User>>(i => _mapper.Map<IEnumerable<UserEntryEditDTO>>(i));

                UserService userService = mock.Create<UserService>();
                UserEntryListDTO result1 = await userService.GetAllEntriesSupervisorsById(1);
                UserEntryListDTO result2 = await userService.GetAllEntriesSupervisorsById(2);

                Assert.True(result1.Supervised.Count() == 1);
                Assert.True(result1.Supervised.First().Id == 2);
                Assert.True(result2.Supervised.Count() == 0);
            }
        }
        [Fact]
        public async Task TestGetUserSupervisionsAsync()
        {
            using (AutoMock mock = AutoMock.GetLoose())
            {
                mock.Mock<IUnitOfWork>()
                   .Setup(x => x.Users.GetById(It.IsAny<int>()))
                   .Returns<int>(i => UsersTestDBSample.GetMockUserById(i));

                mock.Mock<IUnitOfWork>()
                   .Setup(x => x.Users.GetFinanceSupervisored(It.IsAny<int>()))
                   .Returns<int>(i => UsersTestDBSample.GetMockFinanceSupervisored(i));

                mock.Mock<IMapper>()
                    .Setup(x => x.Map<ISet<UserListDTO>>(It.IsAny<IEnumerable<User>>()))
                    .Returns<IEnumerable<User>>(i => _mapper.Map<ISet<UserListDTO>>(i));

                mock.Mock<IMapper>()
                    .Setup(x => x.Map<UserListDTO>(It.IsAny<User>()))
                    .Returns<User>(i => _mapper.Map<UserListDTO>(i));

                UserService userService = mock.Create<UserService>();
                UserSupervisionsDTO result1 = await userService.GetUserSupervisions(1);
                UserSupervisionsDTO result2 = await userService.GetUserSupervisions(2);

                Assert.True(result1.EntriesSupervisors.Count == 0);
                Assert.True(result1.EntriesSupervisedUsers.Count == 1);
                Assert.True(result1.EntriesSupervisedUsers.First().Id == 2);
                Assert.Null(result1.FinanceSupervisor);
                Assert.True(result1.FinanceSupervisedUsers.Count == 1);
                Assert.True(result1.FinanceSupervisedUsers.First().Id == 2);

                Assert.True(result2.EntriesSupervisors.Count == 1);
                Assert.True(result2.EntriesSupervisors.First().Id == 1);
                Assert.True(result2.EntriesSupervisedUsers.Count == 0);
                Assert.NotNull(result2.FinanceSupervisor);
                Assert.True(result2.FinanceSupervisor.Id == 1);
                Assert.True(result2.FinanceSupervisedUsers.Count == 0);
            }
        }
    }
}
