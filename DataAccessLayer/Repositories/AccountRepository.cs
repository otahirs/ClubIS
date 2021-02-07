using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class AccountRepository : Repository<FinanceAccount>, IAccountRepository
    {
        public AccountRepository(DataContext context) : base(context)
        {
        }
    }
}
