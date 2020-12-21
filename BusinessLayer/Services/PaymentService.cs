using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        }
        public Task Create(PaymentEditDTO p)
        {
            var payment = _mapper.Map<Payment>(p);
            payment.Date = DateTime.Now;
            payment.PaymentState = PaymentState.Ok;
            return _unitOfWork.Payments.Add(payment);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Payments.Remove(await _unitOfWork.Payments.GetById(id));
        }

        public async Task<IEnumerable<PaymentListDTO>> GetAll()
        {
            var paymentEntities = await _unitOfWork.Payments.GetAllIncluded();
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }
        public async Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            var paymentEntities = await _unitOfWork.Payments.GetAllIncludedByAccountId(user.AccountId);
            foreach(var p in paymentEntities)
            {
                if (p.SourceAccountId == user.AccountId)
                    p.CreditAmount *= -1;
            }
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }

        public async Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList()
        {
            return _mapper.Map<IEnumerable<UserCreditListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id)
        {
            var paymentsEntities = await _unitOfWork.Payments.GetAllWithTargetAccountOwnerByEventId(id);
            return _mapper.Map<IEnumerable<PaymentEntryListDTO>>(paymentsEntities);
        }

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _unitOfWork.Payments.GetEventPaymentSumByEventId(id);
        }
    }
}
