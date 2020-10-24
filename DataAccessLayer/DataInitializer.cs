using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Enums;

namespace DataAccessLayer
{
    public static class DataInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(new Address()
            {
                Id = 1,
                StreetAndNumber = "***REMOVED***",
                City = "Brno",
                PostalCode = "***REMOVED***"
            },
            new Address()
            {
                Id = 2,
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


            UserRole ur1 = new UserRole() { Id = 1, Role = Role.Member };
            UserRole ur2 = new UserRole() { Id = 5, Role = Role.EntriesManager };
            modelBuilder.Entity<UserRole>().HasData(ur1, ur2);

            User_EntriesSupervisor ues = new User_EntriesSupervisor()
            {
                UserId = 2,
                EntriesSupervisorId = 1

            };
            modelBuilder.Entity<User_EntriesSupervisor>().HasData(ues);

            User supervisor = new User
            {
                Id = 1,
                EntriesSupervisedUsers = new List<User_EntriesSupervisor>() { ues },
                AddressId = 1,
                MemberFeeId = 2,
                Username = "m.chaloup",
                Password = "123456",
                Firstname = "Matěj",
                Surname = "***REMOVED***",
                SiCardNumber = 2129226,
                RegistrationNumber = 1403,
                Nationality = "Česká republika",
                Email = "tst2@eof.cz",
                Gender = Gender.Male,
                Licence = Licence.C,
                AccountState = AccountState.Archived,
                Roles = new List<UserRole>() { ur1, ur2 }
            };
            User supervised = new User()
            {
                Id = 2,
                BillingUserId = 1,
                EntriesSupervisors = new List<User_EntriesSupervisor>() { ues },
                AddressId = 2,
                MemberFeeId = 1,
                Username = "kachna",
                Password = "password",
                Firstname = "Kateřina",
                Surname = "***REMOVED***",
                SiCardNumber = ***REMOVED***,
                RegistrationNumber = 0352,
                Nationality = "Česká republika",
                Email = "tst2@eob.cz",
                Gender = Gender.Female,
                Licence = Licence.A,
                AccountState = AccountState.Active,
                Roles = new List<UserRole>() { ur1 }
            };
            modelBuilder.Entity<User>().HasData(supervisor, supervised);

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
                AccommodationOption = Enums.ClubEventOptions.Optional,
                TransportOption = Enums.ClubEventOptions.ClubEnsured,
                Link = "mcr2020.obopava.cz",
                Deadlines = new List<DateTime>() { 
                    new DateTime(2020, 9, 11),
                    new DateTime(2020, 9, 30)
                },
                ClassOptions = new List<string>() { 
                    "A",
                    "B"
                },
                EventType = EventType.Race,
                EventState = EventState.Archived,
                EventProperties = EventProperties.Championship
            });

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                UserId = 2,
                EventId = 1,
                Class = "A",
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                Id = 1,
                AccountOwnerId = 2,
                EventId = 1,
                CreditAmount = 1000,
                PaymentState = PaymentState.Ok
            });
        }
    }
}
