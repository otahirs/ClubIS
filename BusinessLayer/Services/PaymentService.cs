using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
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

        public async Task<int> GetEventPaymentSumByEventId(int id)
        {
            return await _unitOfWork.Payments.GetEventPaymentSumByEventId(id);
        }
    }
}
