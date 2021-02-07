using ClubIS.CoreLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.DataAccessLayer.Repositories.Interfaces
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetAllByAccountId(int accountId);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task<IEnumerable<Payment>> GetAllByEventId(int id);
    }
}
