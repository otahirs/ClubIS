using clubIS.BusinessLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services.Interfaces
{
    public interface IPaymentService
    {
        public Task Create(SendPaymentDTO p);
        public Task<IEnumerable<PaymentListDTO>> GetAll();
        public Task<IEnumerable<PaymentListDTO>> GetByUserId();
        public Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList();
        public void Delete(int id);
    }
}
