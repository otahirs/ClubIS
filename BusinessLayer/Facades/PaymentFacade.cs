﻿using AutoMapper;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClubIS.BusinessLayer.Facades
{
    public class PaymentFacade : IPaymentFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IMemberFeeService _memberFeeService;
        private readonly IMapper _mapper;
        public PaymentFacade(IUnitOfWork unitOfWork, IPaymentService paymentService, IMemberFeeService memberFeeService, IUserService userService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _userService = userService;
            _memberFeeService = memberFeeService;
            _mapper = mapper;
        }

        public async Task Create(PaymentEditDTO payment)
        {
            await _paymentService.Create(payment);
            await _unitOfWork.Save();
        }

        public async Task Create(PaymentUserTransferDTO p)
        {
            PaymentEditDTO payment = _mapper.Map<PaymentEditDTO>(p);
            UserDTO recipientUser = await _userService.GetById((int)p.RecipientUserId);
            UserDTO sourceUser = await _userService.GetById(p.SourceUserId);

            payment.RecipientAccountId = recipientUser.AccountId;
            payment.SourceAccountId = sourceUser.AccountId;
            payment.ExecutorId = sourceUser.Id;

            await _paymentService.Create(payment);
            await _unitOfWork.Save();
        }

        public async Task Create(PaymentGiveCreditDTO p, int executorId)
        {
            UserDTO recipientUser = await _userService.GetById(p.RecipientUserId);
            PaymentEditDTO payment = _mapper.Map<PaymentEditDTO>(p);
            payment.RecipientAccountId = recipientUser.AccountId;
            payment.ExecutorId = executorId;
            await _paymentService.Create(payment);
            await _unitOfWork.Save();
        }

        public async Task Create(PaymentTakeCreditDTO p, int executorId)
        {
            UserDTO sourceUser = await _userService.GetById(p.SourceUserId);
            PaymentEditDTO payment = _mapper.Map<PaymentEditDTO>(p);
            payment.SourceAccountId = sourceUser.AccountId;
            payment.ExecutorId = executorId;
            await _paymentService.Create(payment);
            await _unitOfWork.Save();
        }

        public async Task Delete(int id)
        {
            await _paymentService.Delete(id);
            await _unitOfWork.Save();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public async Task<IEnumerable<PaymentListDTO>> GetAll()
        {
            return await _paymentService.GetAll();
        }

        public async Task<IEnumerable<FinanceStatementDTO>> GetAllFinanceStatement(int userId)
        {
            List<FinanceStatementDTO> result = new List<FinanceStatementDTO>()
            {
                await _paymentService.GetFinanceStatement(userId)
            };

            foreach (CoreLayer.Entities.User user in await _unitOfWork.Users.GetFinanceSupervisored(userId))
            {
                result.Add(await _paymentService.GetFinanceStatement(user.Id));
            }
            return result;
        }
        public async Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id)
        {
            return await _paymentService.GetAllByEventID(id);
        }

        public async Task<IEnumerable<FinanceUserListDTO>> GetAllUserCreditList()
        {
            return await _paymentService.GetAllUSerCreditList();
        }

        public async Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id)
        {
            return await _paymentService.GetPaymentEntryListByEventId(id);
        }

        public async Task<IEnumerable<MemberFeeDTO>> GetAllMemberFeeTypes()
        {
            return await _memberFeeService.GetAll();
        }

        public async Task CreatMemberFee(MemberFeeDTO feeType)
        {
            await _memberFeeService.Create(feeType);
            await _unitOfWork.Save();
        }

        public async Task UpdateMemberFee(MemberFeeDTO feeType)
        {
            await _memberFeeService.Update(feeType);
            await _unitOfWork.Save();
        }

        public async Task DeleteMemberFee(int id)
        {
            await _memberFeeService.Delete(id);
            await _unitOfWork.Save();
        }
    }
}
