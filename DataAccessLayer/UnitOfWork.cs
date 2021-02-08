using ClubIS.DataAccessLayer.Repositories;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        public IUserRepository Users { get; private set; }
        public IEventRepository Events { get; private set; }
        public IStageRepository Stages { get; private set; }
        public INewsRepository News { get; private set; }
        public IPaymentRepository Payments { get; private set; }
        public IAccountRepository Accounts { get; private set; }
        public IEntryRepository Entry { get; private set; }
        public IMemberFeeRepository MemberFees { get; private set; }
        public IAddressRepository Adresses { get; private set; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
            Users = new UserRepository(_context);
            Events = new EventRepository(_context);
            Stages = new StageRepository(_context);
            News = new NewsRepository(_context);
            Entry = new EntryRepository(_context);
            Payments = new PaymentRepository(_context);
            Accounts = new AccountRepository(_context);
            MemberFees = new MemberFeeRepository(_context);
            Adresses = new AddressRepository(_context);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
