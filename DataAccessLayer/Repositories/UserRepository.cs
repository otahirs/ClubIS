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
                        Firstname = u.Firstname,
                        Surname = u.Surname,
                        RegistrationNumber = u.RegistrationNumber
                    }
                )
                .ToListAsync();
        }
    }
}
