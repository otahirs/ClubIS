using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using ClubIS.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Create(PaymentEditDTO p)
        {
            Payment payment = _mapper.Map<Payment>(p);
            payment.Date = DateTime.Now;
            payment.PaymentState = PaymentState.Ok;
            if (p.SourceAccountId != null)
            {
                FinanceAccount source = await _unitOfWork.Accounts.GetById((int)p.SourceAccountId);
                source.CreditBalance -= payment.CreditAmount;
            }
            if (p.RecipientAccountId != null)
            {
                FinanceAccount recipient = await _unitOfWork.Accounts.GetById((int)p.RecipientAccountId);
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
            IEnumerable<Payment> paymentEntities = await _unitOfWork.Payments.GetAll();
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }

        public async Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id)
        {
            IEnumerable<Payment> paymentEntities = await _unitOfWork.Payments.GetAllByEventId(id);
            return _mapper.Map<IEnumerable<PaymentListDTO>>(paymentEntities);
        }
        public async Task<FinanceStatementDTO> GetFinanceStatement(int userId)
        {
            User user = await _unitOfWork.Users.GetById(userId);
            IEnumerable<Payment> paymentEntities = await _unitOfWork.Payments.GetAllByAccountId(user.AccountId);
            foreach (Payment p in paymentEntities)
            {
                if (p.SourceAccountId == user.AccountId)
                {
                    p.CreditAmount *= -1;
                }
            }
            return new FinanceStatementDTO()
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
            IEnumerable<Payment> paymentsEntities = await _unitOfWork.Payments.GetAllByEventId(id);
            return _mapper.Map<IEnumerable<PaymentEntryListDTO>>(paymentsEntities);
        }

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _unitOfWork.Payments.GetEventPaymentSumByEventId(id);
        }
    }
}
