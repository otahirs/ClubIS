using clubIS.DataAccessLayer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using clubIS.DataAccessLayer.Entities;
using System.Linq.Expressions;

namespace clubIS.DataAccessLayer.Repositories
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public PaymentRepository(DataContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Payment>> GetAllWithAccounts()
        {
            return await _entities
                .Include(p => p.SourceAccount)
                .Include(p => p.TargetAccount)
                .ToListAsync();
        }
        public async Task<IEnumerable<Payment>> GetWhereWithAccounts(Expression<Func<Payment, bool>> predicate)
        {
            return await _entities
                .Include(p => p.SourceAccount)
                .Include(p => p.TargetAccount)
                .Where(predicate)
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
