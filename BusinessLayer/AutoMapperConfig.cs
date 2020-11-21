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
            config.CreateMap<EventEntry, EventEntriesListDTO>().ReverseMap();
            config.CreateMap<Tuple<User, Payment>, PaymentEntryListDTO>()
                .ForMember(d => d.Firstname, opt => opt.MapFrom(s => s.Item1.Firstname))
                .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.Item1.Surname))
                .ForMember(d => d.RegistrationNumber, opt => opt.MapFrom(s => s.Item1.RegistrationNumber))
                .ForMember(d => d.UserId, opt => opt.MapFrom(s => s.Item1.Id))
                .ForMember(d => d.PaymentId, opt => opt.MapFrom(s => s.Item2.Id))
                .ForMember(d => d.CreditAmount, opt => opt.MapFrom(s => s.Item2.CreditAmount))
                .ForMember(d => d.Message, opt => opt.MapFrom(s => s.Item2.Message))
                .ReverseMap();
            config.CreateMap<Event, EventListDTO>().ReverseMap();
            config.CreateMap<EventStage, EventStageDTO>().ReverseMap();
            // TODO config.CreateMap<Tuple<Event, Payment>, FinanceEventListDTO>().ReverseMap();
            config.CreateMap<MemberFee, MemberFeeDTO>().ReverseMap();
            config.CreateMap<News, NewsEditDTO>().ReverseMap();
            config.CreateMap<News, NewsListDTO>()
                .ForMember(d => d.UserName, opt => opt.MapFrom(s => s.User.Firstname + " " + s.User.Surname))
                .ReverseMap();
            //TODO config.CreateMap<Payment, PaymentListDTO>().ReverseMap();
            config.CreateMap<Payment, PaymentSendDTO>().ReverseMap();
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
