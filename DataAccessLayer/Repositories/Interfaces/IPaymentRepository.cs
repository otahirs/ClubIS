using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.Entities;

namespace clubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllIncluded();
        Task<IEnumerable<Payment>> GetAllIncludedByAccountId(int accountId);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task<IEnumerable<Payment>> GetAllWithTargetAccountOwnerByEventId(int id);
    }
}
