using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using clubIS.CoreLayer.DTOs;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        Task Create(PaymentSendDTO p);
        Task<IEnumerable<PaymentListDTO>> GetAll();
        Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int id);
        Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList();
        Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        Task<int> GetEventPaymentSumByEventId(int id);
        Task Delete(int id);
    }
}
