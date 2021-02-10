using AutoMapper;
using ClubIS.CoreLayer.DTOs;
using ClubIS.CoreLayer.Entities;
using System.Linq;

namespace ClubIS.BusinessLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<EventEntry, EventEntryBasicInfoDTO>().ReverseMap();
            CreateMap<EventEntry, EventEntryDTO>()
                .ForMember(d => d.Name, opt => opt.MapFrom(s => s.User.Firstname + " " + s.User.Surname))
                .ForMember(d => d.RegistrationNumber, opt => opt.MapFrom(s => s.User.RegistrationNumber))
                .ForMember(d => d.EnteredStages, opt => opt.MapFrom(s => s.EnteredStages));
            CreateMap<EventEntryDTO, EventEntry>()
                .ForMember(d => d.EnteredStages, opt => opt.Ignore());

            CreateMap<Event, EventListDTO>().ReverseMap();
            CreateMap<EventStage, EventStageDTO>().ReverseMap();

            // TODO CreateMap<Tuple<Event, Payment>, FinanceEventListDTO>().ReverseMap();
            CreateMap<MemberFee, MemberFeeDTO>().ReverseMap();
            CreateMap<News, NewsEditDTO>().ReverseMap();
            CreateMap<News, NewsListDTO>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.Firstname + " " + s.User.Surname));
            CreateMap<Payment, PaymentEditDTO>().ReverseMap();
            CreateMap<PaymentGiveCreditDTO, PaymentEditDTO>();
            CreateMap<PaymentTakeCreditDTO, PaymentEditDTO>();
            CreateMap<PaymentUserTransferDTO, PaymentEditDTO>().ReverseMap();
            CreateMap<Payment, PaymentListDTO>()
                .ForMember(d => d.ExecutorName, opt => opt.MapFrom(s => s.ExecutorId.HasValue ? $"{s.Executor.Firstname} {s.Executor.Surname}" : ""))
                .ForMember(d => d.SourceAccountName, opt => opt.MapFrom(s => $"{s.SourceAccount.Owner.Firstname} {s.SourceAccount.Owner.Surname}"))
                .ForMember(d => d.TargetAccountName, opt => opt.MapFrom(s => $"{s.RecipientAccount.Owner.Firstname} {s.RecipientAccount.Owner.Surname}"))
                .ForMember(d => d.EventName, opt => opt.MapFrom(s => s.EventId.HasValue ? s.Event.Name : ""));
            CreateMap<Payment, PaymentEntryListDTO>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.RecipientAccount.Owner.Firstname))
                .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.RecipientAccount.Owner.Surname))
                .ForMember(d => d.RegistrationNumber, opt => opt.MapFrom(s => s.RecipientAccount.Owner.RegistrationNumber))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.RecipientAccount.Owner.Id))
                .ForMember(d => d.PaymentId, opt => opt.MapFrom(s => s.Id));
            CreateMap<User, UserAdministrationDTO>().ReverseMap();
            CreateMap<User, FinanceUserListDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, MemberUserEditDTO>().ReverseMap();
            CreateMap<User, UserEntriesSupervisedListDTO>().ReverseMap();
            CreateMap<User, UserListDTO>().ReverseMap();
            CreateMap<User, UserEntryEditDTO>()
                .ForMember(d => d.SiCardNumbers, opt => opt.MapFrom(s => s.SiCards))
                .ForMember(d => d.Name, opt => opt.MapFrom(s => $"{s.Firstname} {s.Surname}"));
            CreateMap<SiCard, SiCardDTO>().ReverseMap();
        }
    }
}
