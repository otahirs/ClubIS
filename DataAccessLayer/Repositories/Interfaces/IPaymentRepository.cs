using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.Entities;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllIncluded();
        Task<IEnumerable<Payment>> GetAllIncludedByAccountId(int accountId);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task<IEnumerable<Payment>> GetAllWithTargetAccountOwnerByEventId(int id);
    }
}
