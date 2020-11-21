using AutoMapper;
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
            var paymentEntities = await _unitOfWork.Payments.GetAllWithAccounts();
           return await PaymentListMapper(paymentEntities);
        }
        public async Task<IEnumerable<PaymentListDTO>> GetAllByUserId(int id)
        {
            var user = await _unitOfWork.Users.GetById(id);
            var paymentEntities = await _unitOfWork.Payments
                .GetWhereWithAccounts(p => p.SourceAccountId == user.AccountId || p.TargetAccountId == user.AccountId);
            return await PaymentListMapper(paymentEntities);
        }

        private async Task<IEnumerable<PaymentListDTO>> PaymentListMapper(IEnumerable<Payment> list)
        {
            var users = await _unitOfWork.Users.GetAllNameAndRegNumOnly();
            var events = await _unitOfWork.Events.GetAll();
            return list.Select(p => new PaymentListDTO
            {
                ExecutorName = p.ExecutorId.HasValue ? users.Where(u => u.Id == p.ExecutorId.Value).Select(u => $"{u.Firstname} {u.Surname}").First() : "",
                SourceAccountName = users.Where(u => u.Id == p.SourceAccount.Id).Select(u => $"{u.Firstname} {u.Surname}").First(),
                TargetAccountName = users.Where(u => u.Id == p.TargetAccount.Id).Select(u => $"{u.Firstname} {u.Surname}").First(),
                EventName = p.EventId.HasValue ? events.Where(e => e.Id == p.EventId.Value).First().Name : "",
                CreditAmount = p.CreditAmount,
                Message = p.Message,
                PaymentState = p.PaymentState,
                StornoNote = p.StornoNote
            });
        }

        public async Task<IEnumerable<UserCreditListDTO>> GetAllUSerCreditList()
        {
            return _mapper.Map<IEnumerable<UserCreditListDTO>>(await _unitOfWork.Users.GetAll());
        }

        public async Task<IEnumerable<PaymentSumEventListDTO>> GetAllEventSum()
        {
            var events = _mapper.Map<IEnumerable<EventListDTO>>(await _unitOfWork.Events.GetAll());
            return await Task.WhenAll(events
                .Select(async e => new PaymentSumEventListDTO
                {
                    EventList = e,
                    TotalCosts = await _unitOfWork.Payments.GetEventPaymentSumByEventId(e.Id)
                }));
        }

        public async Task<IEnumerable<PaymentEntryListDTO>> GetPaymentEntryListByEventId(int id)
        {
            var payments = await _unitOfWork.Payments.GetWhere(p => p.EventId == id);
            return await Task.WhenAll(payments
                .Select(async 
                    payment => _mapper.Map<PaymentEntryListDTO>(
                        Tuple.Create(
                            await _unitOfWork.Users.GetNameAndRegNumOnlyByAccountId(payment.SourceAccountId),
                            payment
                        )
                    )
                ));
        }
    }
}
