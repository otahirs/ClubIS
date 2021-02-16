using System;
using System.Collections.Generic;
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
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task Create(PaymentEditDTO p)
        {
            var payment = _mapper.Map<Payment>(p);
            payment.Date = DateTime.Now;
            payment.PaymentState = PaymentState.Ok;
            if (p.SourceAccountId != null)
            {
                var source = await _unitOfWork.Accounts.GetById((int) p.SourceAccountId);
                source.CreditBalance -= payment.CreditAmount;
            }

            if (p.RecipientAccountId != null)
            {
                var recipient = await _unitOfWork.Accounts.GetById((int) p.RecipientAccountId);
                recipient.CreditBalance += payment.CreditAmount;
            }

            await _unitOfWork.Payments.Add(payment);
        }

        public async Task Delete(int id)
        {
            _unitOfWork.Payments.Remove(await _unitOfWork.Payments.GetById(id));
        }

        public async Task<IEnumerable<PaymentListDTO>> GetAll()
        {
            var paymentEntities = await _unitOfWork.Payments.GetAll();
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }

        public async Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id)
        {
            var paymentEntities = await _unitOfWork.Payments.GetAllByEventId(id);
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }

        public async Task<FinanceStatementDTO> GetFinanceStatement(int userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            var paymentEntities = await _unitOfWork.Payments.GetAllByAccountId(user.AccountId);
            foreach (var p in paymentEntities)
                if (p.SourceAccountId == user.AccountId)
                    p.CreditAmount *= -1;
            return new FinanceStatementDTO
            {
                UserId = user.Id,
                Name = user.Surname + " " + user.Firstname,
                AccountId = user.AccountId,
                CreditBalance = user.Account.CreditBalance,
                Payments = _mapper.Map<List<PaymentListDTO>>(paymentEntities)
            };
        }

        public async Task<IEnumerable<FinanceUserListDTO>> GetAllUSerCreditList()
        {
            return _mapper.Map<IEnumerable<FinanceUserListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id)
        {
            var paymentsEntities = await _unitOfWork.Payments.GetAllByEventId(id);
            return _mapper.Map<IEnumerable<PaymentEntryListDTO>>(paymentsEntities);
        }

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _unitOfWork.Payments.GetEventPaymentSumByEventId(id);
        }

        public async Task Update(PaymentEditDTO payment)
        {
            var paymentEntity = await _unitOfWork.Payments.GetById(payment.Id);
            _mapper.Map(payment, paymentEntity);
        }

        public async Task<PaymentEditDTO> GetById(int id)
        {
            return _mapper.Map<PaymentEditDTO>(await _unitOfWork.Payments.GetById(id));
        }
    }
}