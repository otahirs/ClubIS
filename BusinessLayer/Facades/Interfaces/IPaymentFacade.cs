using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IPaymentFacade : IDisposable
    {
        Task Create(PaymentEditDTO p);
        Task Create(PaymentUserTransferDTO p);
        Task Create(PaymentGiveCreditDTO payment, int executorId);
        Task Create(PaymentTakeCreditDTO payment, int executorId);
        Task Create(PaymentEntryListDTO payment, int executorId);
        Task Update(PaymentEntryListDTO payment, int executorId);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<FinanceStatementDTO>> GetAllFinanceStatement(int userId);
        Task<IEnumerable<FinanceUserListDTO>> GetAllUserCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventId(int id);
        Task Delete(int id);
        Task<IEnumerable<MemberFeeDTO>> GetAllMemberFeeTypes();
        Task CreateMemberFee(MemberFeeDTO feeType);
        Task UpdateMemberFee(MemberFeeDTO feeType);
        Task DeleteMemberFee(int id);
        Task UpdatePaymentEntryList(IEnumerable<PaymentEntryListDTO> payments, int executorId);
    }
}