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
        Task Create(PaymentGiveCreditDTO payment, int executorId);
        Task Create(PaymentTakeCreditDTO payment, int executorId);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<FinanceStatementDTO>> GetAllFinanceStatement(int userId);
        Task<IEnumerable<FinanceUserListDTO>> GetAllUserCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id);
        Task Delete(int id);
        Task<IEnumerable<MemberFeeDTO>> GetAllMemberFeeTypes();
        Task CreatMemberFee(MemberFeeDTO feeType);
        Task UpdateMemberFee(MemberFeeDTO feeType);
        Task DeleteMemberFee(int id);
    }
}
