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
            var supervisions = new List<Supervision>
            {
                new Supervision
                {
                    SupervisorUserId = 1,
                    SupervisedUserId = 2,
                    IsEntrySupervisionEnabled = true,
                    IsFinanceSupervisionEnabled = true
                }
            };
            var users = new List<User>
            {
                new()
                {
                    Id = 1,
                    AccountId = 2,
                    Firstname = "Matěj",
                    Surname = "Perník",
                    RegistrationNumber = "ZBM1108",
                    Nationality = "Česká republika",
                    Email = "tst2@eof.cz",
                    Gender = Gender.Male,
                    Licence = Licence.C,
                    AccountState = AccountState.Archived,
                    UnderSupervision = supervisions
                },
                new()
                {
                    Id = 2,
                    AccountId = 1,
                    Firstname = "Kateřina",
                    Surname = "Muflonová",
                    RegistrationNumber = "ZMB9751",
                    Nationality = "Česká republika",
                    Email = "tst2@eob.cz",
                    Gender = Gender.Female,
                    Licence = Licence.A,
                    AccountState = AccountState.Active,
                    SupervisedBy = supervisions
                }
            };

            return users;
        }

        public static Task<User> GetMockUserById(int id)
        {
            return Task.FromResult(GetMockUsers().FirstOrDefault(u => u.Id == id));
        }

    }
}