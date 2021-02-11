using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ClubIS.DataAccessLayer
{
    public static class DataInitializer
    {
        // PostgreSQL cannot handle Id autogeration after seeding, workaround is to seed from MaxValue
        private static readonly int ID_1 = int.MaxValue;
        private static readonly int ID_2 = int.MaxValue - 1;
        private static readonly int ID_3 = int.MaxValue - 2;
        private static readonly int ID_4 = int.MaxValue - 3;
        private static readonly int ID_5 = int.MaxValue - 4;
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasData(new Address()
            {
                Id = ID_1,
                UserId = ID_1,
                StreetAndNumber = "***REMOVED***",
                City = "Brno",
                PostalCode = "***REMOVED***"
            },
            new Address()
            {
                Id = ID_2,
                UserId = ID_2,
                City = "***REMOVED***",
                PostalCode = "***REMOVED***"
            });

            modelBuilder.Entity<MemberFee>().HasData(new MemberFee()
            {
                Id = ID_2,
                Name = "All Inclusive",
                Description = "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.",
                Amount = 0,
                MemberFeeType = MemberFeeType.All
            },
            new MemberFee()
            {
                Id = ID_1,
                Name = "Základ",
                Description = "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.",
                Amount = 100,
                MemberFeeType = MemberFeeType.Basic
            });

            User supervisor = new User
            {
                Id = ID_1,
                AccountId = ID_1,
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
                Id = ID_2,
                AccountId = ID_2,
                FinanceSupervisorId = ID_1,
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

            modelBuilder.Entity("User_EntriesSupervisor").HasData(
              new Dictionary<string, object> { ["UserId"] = ID_1, ["EntriesSupervisorId"] = ID_2 }
            );

            modelBuilder.Entity<FinanceAccount>().HasData(new FinanceAccount()
            {
                Id = ID_1,
                CreditBalance = 0,
            });

            modelBuilder.Entity<FinanceAccount>().HasData(new FinanceAccount()
            {
                Id = ID_2,
                CreditBalance = 0,
            });

            modelBuilder.Entity<SiCard>().HasData(
                new SiCard()
                {
                    Id = ID_1,
                    UserId = ID_1,
                    Number = ***REMOVED***,
                    IsDefault = true
                },
                new SiCard()
                {
                    Id = ID_2,
                    UserId = ID_2,
                    Number = ***REMOVED***,
                    IsDefault = true
                }
            );

            modelBuilder.Entity<News>().HasData(new News()
            {
                Id = ID_1,
                UserId = ID_1,
                Date = new DateTime(2020, 9, 30),
                Title = "test nadpisu",
                Text = "1111111111111111111111111111111111111111111111111111111111111111111111111111111",
            });

            modelBuilder.Entity<Event>().HasData(new Event()
            {
                Id = ID_1,
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
                Id = ID_2,
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
                   Id = ID_1,
                   EventId = ID_1,
                   Deadline = new DateTime(2021, 9, 1)
               }
            );

            modelBuilder.Entity<EventDeadline>().HasData(
                new EventDeadline()
                {
                    Id = ID_2,
                    EventId = ID_2,
                    Deadline = new DateTime(2021, 10, 1)
                },
                new EventDeadline()
                {
                    Id = ID_3,
                    EventId = ID_2,
                    Deadline = new DateTime(2021, 10, 5)
                }
            );

            modelBuilder.Entity<EventClassOption>().HasData(
                new EventClassOption()
                {
                    Id = ID_1,
                    EventId = ID_1,
                    Name = "A"
                },
                new EventClassOption()
                {
                    Id = ID_2,
                    EventId = ID_1,
                    Name = "B"
                }
            );

            modelBuilder.Entity<EventClassOption>().HasData(
                new EventClassOption()
                {
                    Id = ID_3,
                    EventId = ID_2,
                    Name = "A"
                },
                new EventClassOption()
                {
                    Id = ID_4,
                    EventId = ID_2,
                    Name = "B"
                },
                new EventClassOption()
                {
                    Id = ID_5,
                    EventId = ID_2,
                    Name = "H20"
                }
            );

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                Id = ID_1,
                UserId = ID_2,
                EventId = ID_1,
                Class = "A",
                SiCardNumber = ***REMOVED***,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<EventEntry>().HasData(new EventEntry()
            {
                Id = ID_2,
                UserId = ID_1,
                EventId = ID_2,
                Class = "H20",
                SiCardNumber = ***REMOVED***,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<Payment>().HasData(new Payment()
            {
                Id = ID_1,
                ExecutorId = ID_1,
                SourceAccountId = ID_1,
                RecipientAccountId = ID_2,
                EventId = ID_1,
                CreditAmount = 1000,
                PaymentState = PaymentState.Ok
            });

            PasswordHasher<UserIdentity> hasher = new PasswordHasher<UserIdentity>();
            modelBuilder.Entity<UserIdentity>().HasData(
                new UserIdentity
                {
                    Id = ID_1,
                    UserName = "matej",
                    NormalizedUserName = "MATEJ",
                    PasswordHash = hasher.HashPassword(null, "matej"),
                    SecurityStamp = string.Empty
                },
                new UserIdentity
                {
                    Id = ID_2,
                    UserName = "katka",
                    NormalizedUserName = "KATKA",
                    PasswordHash = hasher.HashPassword(null, "katka"),
                    SecurityStamp = string.Empty
                }
            );

            // make matej admin
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = ID_1
            });


        }
    }
}
