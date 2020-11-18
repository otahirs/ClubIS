using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetWhereWithAccounts(Expression<Func<Payment, bool>> predicate);
        Task<IEnumerable<Payment>> GetAllWithAccounts();
        Task<int> GetEventPaymentSumByEventId(int id);
    }
}
