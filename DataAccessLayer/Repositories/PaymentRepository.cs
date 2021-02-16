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

        public async Task<IEnumerable<Payment>> GetAllByAccountId(int accountId)
        {
            return await _entities.Where(p => p.SourceAccountId == accountId || p.RecipientAccountId == accountId).ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetAllByEventId(int id)
        {
            return await _entities.Where(p => p.EventId == id).ToListAsync();
        }

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _entities.Where(p => p.EventId == id).Select(p => p.CreditAmount).SumAsync();
        }
    }
}