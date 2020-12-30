using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class AccountRepository : Repository<FinanceAccount>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {
        }
    }
}
