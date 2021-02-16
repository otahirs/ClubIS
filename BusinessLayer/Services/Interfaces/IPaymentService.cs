using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        Task Create(PaymentEditDTO p);
        Task Update(PaymentEditDTO p);
        Task<PaymentEditDTO> GetById(int id);
        Task<IEnumerable<PaymentListDTO>> GetAll();

        Task<FinanceStatementDTO> GetFinanceStatement(int userId);
        Task<IEnumerable<FinanceUserListDTO>> GetAllUSerCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id);
        Task Delete(int id);
    }
}