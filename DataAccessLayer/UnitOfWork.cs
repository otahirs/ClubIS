using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories;
using ClubIS.DataAccessLayer.Repositories.Interfaces;

namespace ClubIS.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;

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
            Supervisions = new SupervisionRepository(_context);
        }

        public IUserRepository Users { get; }
        public IEventRepository Events { get; }
        public IStageRepository Stages { get; }
        public INewsRepository News { get; }
        public IPaymentRepository Payments { get; }
        public IAccountRepository Accounts { get; }
        public IEntryRepository Entry { get; }
        public IMemberFeeRepository MemberFees { get; }
        public ISupervisionRepository Supervisions { get; }

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