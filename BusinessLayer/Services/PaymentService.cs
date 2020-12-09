﻿using AutoMapper;
using clubIS.BusinessLayer.DTOs;
using clubIS.BusinessLayer.MapperConfig;
using clubIS.BusinessLayer.Services.Interfaces;
using clubIS.DataAccessLayer;
using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace clubIS.BusinessLayer.Services
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
        public Task Create(PaymentSendDTO p)
        {
            return _unitOfWork.Payments.Add(_mapper.Map<Payment>(p));
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
        public async Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            var paymentEntities = await _unitOfWork.Payments.GetAllIncludedByAccountId(user.AccountId);
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
    }
}
