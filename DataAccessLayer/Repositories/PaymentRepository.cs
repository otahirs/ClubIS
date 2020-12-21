using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;
using ClubIS.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Payment>> GetAllIncluded()
        {
            return await _entities
                .Include(p => p.Executor)
                .Include(p => p.SourceAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.RecipientAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.Event)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetAllIncludedByAccountId(int accountId)
        {
            return await _entities
                .Include(p => p.Executor)
                .Include(p => p.SourceUser)
                .Include(p => p.SourceAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.RecipientUser)
                .Include(p => p.RecipientAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.Event)
                .Where(p => p.SourceAccountId == accountId || p.RecipientAccountId == accountId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetAllWithTargetAccountOwnerByEventId(int id)
        {
            return await _entities
                .Include(p => p.RecipientAccount)
                    .ThenInclude(a => a.Owner)
                .Where(p => p.EventId == id)
                .ToListAsync();
        }

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _entities
                .Where(p => p.EventId == id)
                .Select(p => p.CreditAmount)
                .SumAsync();
        }


    }
}
