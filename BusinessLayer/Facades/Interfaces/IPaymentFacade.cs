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
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<FinanceStatementDTO>> GetAllFinanceStatement(int userId);
        Task<IEnumerable<UserCreditListDTO>> GetAllUserCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id);
        Task Delete(int id);
    }
}
