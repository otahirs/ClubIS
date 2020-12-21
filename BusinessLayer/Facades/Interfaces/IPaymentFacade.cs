using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClubIS.CoreLayer.DTOs;

namespace ClubIS.BusinessLayer.Facades.Interfaces
{
    public interface IPaymentFacade : IDisposable
    {
        Task Create(PaymentSendDTO p);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int id);
        Task<IEnumerable<UserCreditListDTO>> GetAllUserCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task Delete(int id);
    }
}
