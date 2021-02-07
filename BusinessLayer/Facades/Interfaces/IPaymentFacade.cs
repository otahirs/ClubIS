using ClubIS.CoreLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IPaymentFacade : IDisposable
    {
        Task Create(PaymentEditDTO p);
        Task Create(PaymentUserTransferDTO p);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<FinanceStatementDTO>> GetAllFinanceStatement(int userId);
        Task<IEnumerable<UserCreditListDTO>> GetAllUserCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id);
        Task Delete(int id);
        Task<IEnumerable<MemberFeeDTO>> GetAllMemberFeeTypes();
    }
}
