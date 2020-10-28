using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Enums;
using clubIS.DataAccessLayer.Entities;

namespace DataAccessLayer
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(new Address()
            {
                Id = 1,
                UserId = 1,
                StreetAndNumber = "***REMOVED***",
                City = "Brno",
                PostalCode = "***REMOVED***"
            },
            new Address()
            {
                Id = 2,
                UserId = 2,
                City = "Brno - Horní Heršpice",
                PostalCode = "***REMOVED***"
            });

            modelBuilder.Entity<MemberFee>().HasData(new MemberFee()
            {
                Id = 2,
                Name = "All Inclusive",
                Description = "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.",
                Amount = 0,
                MemberFeeType = MemberFeeType.All
            },
            new MemberFee()
            {
                Id = 1,
                Name = "Základ",
                Description = "Nikam nejezdím nebo málo - veškeré závody se strhávají z osobního vkladu.",
                Amount = 100,
                MemberFeeType = MemberFeeType.Basic
            });

            User_EntriesSupervisor ues = new User_EntriesSupervisor()
            {
                UserId = 2,
                EntriesSupervisorId = 1

            };
            modelBuilder.Entity<User_EntriesSupervisor>().HasData(ues);

            User supervisor = new User
            {
                Id = 1,
                AccountId = 2,
                BillingAccountId = 1,
                Username = "m.chaloup",
                Password = "123456",
                Firstname = "Matěj",
                Surname = "***REMOVED***",
                RegistrationNumber = "***REMOVED***",
                Nationality = "Česká republika",
                Email = "tst2@eof.cz",
                Gender = Gender.Male,
                Licence = Licence.C,
                AccountState = AccountState.Archived,
                Roles = Role.Member | Role.EntriesManager
            };
            User supervised = new User()
            {
                Id = 2,
                AccountId = 1,
                Username = "kachna",
                Password = "password",
                Firstname = "Kateřina",
                Surname = "***REMOVED***",
                RegistrationNumber = "***REMOVED***",
                Nationality = "Česká republika",
                Email = "tst2@eob.cz",
                Gender = Gender.Female,
                Licence = Licence.A,
                AccountState = AccountState.Active,
                Roles = Role.Member
            };
            modelBuilder.Entity<User>().HasData(supervisor, supervised);

            modelBuilder.Entity<FinanceAccount>().HasData(new FinanceAccount()
            {
                Id = 1,
                CreditBalance = 0,
            });

            modelBuilder.Entity<FinanceAccount>().HasData(new FinanceAccount()
            {
                Id = 2,
                CreditBalance = 0,
            });

            modelBuilder.Entity<SiCard>().HasData(
                new SiCard()
                {
                    Id = 1,
                    UserId = 1,
                    Number = ***REMOVED***,
                    IsDefault = true
                },
                new SiCard()
                {
                    Id = 2,
                    UserId = 2,
                    Number = ***REMOVED***,
                    IsDefault = true
                }
            );

            modelBuilder.Entity<News>().HasData(new News()
            {
                Id = 1,
                UserId = 1,
                Date = new DateTime(2020, 9, 30),
                Title = "test nadpisu",
                Text = "1111111111111111111111111111111111111111111111111111111111111111111111111111111",
                IsPublic = false
            });

            modelBuilder.Entity<Event>().HasData(new Event()
            {
                Id = 1,
                StartDate = new DateTime(2020, 10, 11),
                EndDate = new DateTime(2020, 10, 11),
                Name = "MČR klubů a oblastních výběrů",
                Place = "Kobyla nad Vidnávkou",
                AccommodationOption = ClubEventOption.Optional,
                TransportOption = ClubEventOption.ClubEnsured,
                Link = "mcr2020.obopava.cz",
                ClassOptions = new HashSet<string>() { 
                    "A",
                    "B"
                },
                EventType = EventType.Race,
                EventState = EventState.Archived,
                EventProperties = EventProperty.Championship
            });

            modelBuilder.Entity<EventDeadline>().HasData(
               new EventDeadline()
               {
                   Id = 1,
                   EventId = 1,
                   Deadline = new DateTime(2020, 9, 11)
               },
               new EventDeadline()
               {
                   Id = 2,
                   EventId = 1,
                   Deadline = new DateTime(2020, 9, 30)
               }
           );

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                Id = 1,
                UserId = 2,
                EventId = 1,
                Class = "A",
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                Id = 1,
                ExecutorId = 1,
                SourceAccountId = 1,
                TargetAccountId = 2,
                EventId = 1,
                CreditAmount = 1000,
                PaymentState = PaymentState.Ok
            });
        }
    }
}
