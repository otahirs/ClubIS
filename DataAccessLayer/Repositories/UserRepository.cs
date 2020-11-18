using clubIS.DataAccessLayer.Entities;
using clubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext context) : base(context)
        {  
        }
        public async Task<IEnumerable<User>> GetAllNameAndRegNumOnly()
        {
            return await _entities
                .Select(u => 
                    new User
                    {
                        Id = u.Id,
                        Firstname = u.Firstname,
                        Surname = u.Surname,
                        RegistrationNumber = u.RegistrationNumber
                    }
                )
                .ToListAsync();
        }

        public async Task<User> GetNameAndRegNumOnlyByAccountId(int id)
        {
            return await _entities
                .Select(u =>
                    new User
                    {
                        Id = u.Id,
                        Firstname = u.Firstname,
                        Surname = u.Surname,
                        RegistrationNumber = u.RegistrationNumber
                    }
                )
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
        }


        public async Task<Tuple<string,string>> GetNameByAccountId(int accountId)
        {
            return await _entities
                .Where(u => u.AccountId == accountId)
                .Select(u => Tuple.Create(u.Firstname, u.Surname))
                .FirstOrDefaultAsync();
        }
        public async Task<Tuple<string, string>> GetNameById(int id)
        {
            return await _entities
                .Where(u => u.Id == id)
                .Select(u => Tuple.Create(u.Firstname, u.Surname))
                .FirstOrDefaultAsync();
        }
    }
}
