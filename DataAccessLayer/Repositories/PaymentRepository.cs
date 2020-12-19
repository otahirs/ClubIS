using clubIS.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using clubIS.CoreLayer.Entities;

namespace clubIS.DataAccessLayer.Repositories
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
                .Include(p => p.TargetAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.Event)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetAllIncludedByAccountId(int accountId)
        {
            return await _entities
                .Include(p => p.Executor)
                .Include(p => p.SourceAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.TargetAccount)
                    .ThenInclude(a => a.Owner)
                .Include(p => p.Event)
                .Where(p => p.SourceAccountId == accountId || p.TargetAccountId == accountId)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetAllWithTargetAccountOwnerByEventId(int id)
        {
            return await _entities
                .Include(p => p.TargetAccount)
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
