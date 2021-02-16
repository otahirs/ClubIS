using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;

namespace ClubIS.CoreLayer.TestSamples
{
    public class UsersTestDBSample
    {
        public static IEnumerable<User> GetMockUsers()
        {
            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    AccountId = 2,
                    Firstname = "Matěj",
                    Surname = "***REMOVED***",
                    RegistrationNumber = "***REMOVED***",
                    Nationality = "Česká republika",
                    Email = "tst2@eof.cz",
                    Gender = Gender.Male,
                    Licence = Licence.C,
                    AccountState = AccountState.Archived,
                    EntriesSupervisors = new HashSet<User>(),
                    EntriesSupervisedUsers = new HashSet<User>()
                },
                new()
                {
                    Id = 2,
                    AccountId = 1,
                    FinanceSupervisorId = 1,
                    Firstname = "Kateřina",
                    Surname = "***REMOVED***",
                    RegistrationNumber = "***REMOVED***",
                    Nationality = "Česká republika",
                    Email = "tst2@eob.cz",
                    Gender = Gender.Female,
                    Licence = Licence.A,
                    AccountState = AccountState.Active,
                    EntriesSupervisors = new HashSet<User>(),
                    EntriesSupervisedUsers = new HashSet<User>()
                }
            };
            users[1].EntriesSupervisors.Add(users[0]);
            users[0].EntriesSupervisedUsers.Add(users[1]);
            users[1].FinanceSupervisor = users[0];

            return users;
        }

        public static Task<User> GetMockUserById(int id)
        {
            return Task.FromResult(GetMockUsers().FirstOrDefault(u => u.Id == id));
        }

        public static Task<IEnumerable<User>> GetMockFinanceSupervisored(int id)
        {
            return Task.FromResult(GetMockUsers().Where(u => u.FinanceSupervisorId == id));
        }
    }
}