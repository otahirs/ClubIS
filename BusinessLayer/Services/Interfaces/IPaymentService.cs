using clubIS.BusinessLayer.DTOs;
using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task Create(PaymentSendDTO p);
        public Task<IEnumerable<PaymentListDTO>> GetAll();
        public Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int id);
        public Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList();
        public Task<IEnumerable<PaymentSumEventListDTO>> GetAllEventSum();
        public Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id);
        public Task Delete(int id);
    }
}
