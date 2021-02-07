using ClubIS.CoreLayer.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        Task Create(PaymentEditDTO p);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<FinanceStatementDTO> GetFinanceStatement(int userId);
        Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id);
        Task Delete(int id);
        Task<IEnumerable<MemberFeeDTO>> GetAllMemberFeeTypes();
    }
}
