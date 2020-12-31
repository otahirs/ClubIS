using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ClubIS.BusinessLayer.Facades.Interfaces;
using ClubIS.BusinessLayer.Services.Interfaces;
using ClubIS.CoreLayer.DTOs;
using ClubIS.DataAccessLayer;

namespace ClubIS.BusinessLayer.Facades
{
    public class PaymentFacade : IPaymentFacade
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public PaymentFacade(IUnitOfWork unitOfWork, IPaymentService paymentService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _paymentService = paymentService;
            _userService = userService;
            _mapper = new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping));
        }

        public async Task Create(PaymentEditDTO payment)
        {
            await _paymentService.Create(payment);
            await _unitOfWork.Save();
        }

        public async Task Create(PaymentUserTransferDTO p)
        {
            var payment = _mapper.Map<PaymentEditDTO>(p);
            var recipientUser = await _userService.GetById(p.RecipientUserId);
            var sourceUser = await _userService.GetById(p.SourceUserId);

            payment.RecipientAccountId = recipientUser.AccountId;
            payment.SourceAccountId = sourceUser.AccountId;
            payment.ExecutorId = sourceUser.Id;

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
            var result = new List<FinanceStatementDTO>()
            {
                await _paymentService.GetFinanceStatement(userId)
            };

            foreach( var user in await _unitOfWork.Users.GetFinanceSupervisored(userId))
            {
                result.Add(await _paymentService.GetFinanceStatement(user.Id));
            }
            return result;
        }
        public async Task<IEnumerable<PaymentListDTO>> GetAllByEventID(int id)
        {
            return await _paymentService.GetAllByEventID(id);
        }

        public async Task<IEnumerable<UserCreditListDTO>> GetAllUserCreditList()
        {
            return await _paymentService.GetAllUSerCreditList();
        }

        public async Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id)
        {
            return await _paymentService.GetPaymentEntryListByEventId(id);
        }
    }
}
