using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer
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
                City = "***REMOVED***",
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
                Description = "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.",
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
                Firstname = "Matěj",
                Surname = "***REMOVED***",
                RegistrationNumber = "***REMOVED***",
                Nationality = "Česká republika",
                Email = "tst2@eof.cz",
                Gender = Gender.Male,
                Licence = Licence.C,
                AccountState = AccountState.Archived
            };
            User supervised = new User()
            {
                Id = 2,
                AccountId = 1,
                FinanceSupervisorId = 1,
                Firstname = "Kateřina",
                Surname = "***REMOVED***",
                RegistrationNumber = "***REMOVED***",
                Nationality = "Česká republika",
                Email = "tst2@eob.cz",
                Gender = Gender.Female,
                Licence = Licence.A,
                AccountState = AccountState.Active
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
            });

            modelBuilder.Entity<Event>().HasData(new Event()
            {
                Id = 1,
                StartDate = new DateTime(2021, 9, 7),
                EndDate = new DateTime(2021, 9, 18),
                Name = "Soustředění Vysočina",
                Place = "Sklené",
                Organizer = "OB ZAM",
                AccommodationOption = ClubEventOption.Optional,
                TransportOption = ClubEventOption.ClubEnsured,
                Link = "mcr2020.obopava.cz",
                EventType = EventType.Camp,
                EventState = EventState.Ok,
                EventProperties = EventProperty.Championship
            });

            modelBuilder.Entity<Event>().HasData(new Event()
            {
                Id = 2,
                StartDate = new DateTime(2021, 10, 30),
                EndDate = new DateTime(2021, 10, 30),
                Name = "9. JML  klasická trať",
                Place = "Jilemnice",
                Organizer = "OB ZAM",
                AccommodationOption = ClubEventOption.Optional,
                TransportOption = ClubEventOption.ClubEnsured,
                Link = "mcr2020.obopava.cz",
                EventType = EventType.Race,
                EventState = EventState.Ok,
                EventProperties = EventProperty.Championship
            });

            modelBuilder.Entity<EventDeadline>().HasData(
               new EventDeadline()
               {
                   Id = 1,
                   EventId = 1,
                   Deadline = new DateTime(2021, 9, 1)
               }
            );

            modelBuilder.Entity<EventDeadline>().HasData(
                new EventDeadline()
                {
                    Id = 2,
                    EventId = 2,
                    Deadline = new DateTime(2021, 10, 1)
                },
                new EventDeadline()
                {
                    Id = 3,
                    EventId = 2,
                    Deadline = new DateTime(2021, 10,  5)
                }
            );

            modelBuilder.Entity<EventClassOption>().HasData(
                new EventClassOption()
                {
                    Id = 1,
                    EventId = 1,
                    Name = "A"
                },
                new EventClassOption()
                {
                    Id = 2,
                    EventId = 1,
                    Name = "B"
                }
            );

            modelBuilder.Entity<EventClassOption>().HasData(
                new EventClassOption()
                {
                    Id = 3,
                    EventId = 2,
                    Name = "A"
                },
                new EventClassOption()
                {
                    Id = 4,
                    EventId = 2,
                    Name = "B"
                },
                new EventClassOption()
                {
                    Id = 5,
                    EventId = 2,
                    Name = "H20"
                }
            );

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                Id = 1,
                UserId = 2,
                EventId = 1,
                Class = "A",
                SiCardNumber = ***REMOVED***,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                Id = 2,
                UserId = 1,
                EventId = 2,
                Class = "H20",
                SiCardNumber = ***REMOVED***,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                Id = 1,
                ExecutorId = 1,
                SourceAccountId = 1,
                RecipientAccountId = 2,
                EventId = 1,
                CreditAmount = 1000,
                PaymentState = PaymentState.Ok
            });
        }
    }
}
