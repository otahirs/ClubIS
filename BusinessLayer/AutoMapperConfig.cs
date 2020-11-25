using AutoMapper;
using clubIS.BusinessLayer.DTOs;
using clubIS.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace clubIS.BusinessLayer.MapperConfig
{
    public class AutoMapperConfig
    {       
        public static void ConfigureMapping(IMapperConfigurationExpression config)
        {
            config.CreateMap<Event, EventDetailDTO>().ReverseMap();
            config.CreateMap<Event, EventEditDTO>().ReverseMap();
            config.CreateMap<EventEntry, EventEntryListDTO>().ReverseMap();
            config.CreateMap<EventEntry, EventEntryEditDTO>().ReverseMap();
            config.CreateMap<EventEntry, EventEntryBasicInfoDTO>().ReverseMap();
            config.CreateMap<Event, EventListDTO>().ReverseMap();
            config.CreateMap<EventStage, EventStageDTO>().ReverseMap();
            // TODO config.CreateMap<Tuple<Event, Payment>, FinanceEventListDTO>().ReverseMap();
            config.CreateMap<MemberFee, MemberFeeDTO>().ReverseMap();
            config.CreateMap<News, NewsEditDTO>().ReverseMap();
            config.CreateMap<News, NewsListDTO>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.Firstname + " " + s.User.Surname));
            config.CreateMap<Payment, PaymentSendDTO>().ReverseMap();
            config.CreateMap<Payment, PaymentListDTO>()
                .ForMember(d => d.ExecutorName, opt => opt.MapFrom(s => s.ExecutorId.HasValue ? $"{s.Executor.Firstname} {s.Executor.Surname}" : ""))
                .ForMember(d => d.SourceAccountName, opt => opt.MapFrom(s => $"{s.SourceAccount.Owner.Firstname} {s.SourceAccount.Owner.Surname}"))
                .ForMember(d => d.TargetAccountName, opt => opt.MapFrom(s => $"{s.TargetAccount.Owner.Firstname} {s.TargetAccount.Owner.Surname}"))
                .ForMember(d => d.EventName, opt => opt.MapFrom(s => s.EventId.HasValue ? s.Event.Name : ""));
            config.CreateMap<Payment, PaymentEntryListDTO>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.TargetAccount.Owner.Firstname))
                .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.TargetAccount.Owner.Surname))
                .ForMember(d => d.RegistrationNumber, opt => opt.MapFrom(s => s.TargetAccount.Owner.RegistrationNumber))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.TargetAccount.Owner.Id))
                .ForMember(d => d.PaymentId, opt => opt.MapFrom(s => s.Id));
            config.CreateMap<User, UserAdministrationDTO>().ReverseMap();
            config.CreateMap<User, UserCredentialsEditDTO>().ReverseMap();
            config.CreateMap<User, UserCreditListDTO>().ReverseMap();
            config.CreateMap<User, UserDetailDTO>().ReverseMap();
            config.CreateMap<User, UserEditDTO>().ReverseMap();
            config.CreateMap<User, UserEntriesSupervisedListDTO>().ReverseMap();
            config.CreateMap<User, UserListDTO>().ReverseMap();
        }
    }
}
