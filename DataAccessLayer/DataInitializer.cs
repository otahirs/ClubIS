using System;
using System.Collections.Generic;
using ClubIS.CoreLayer.Entities;
using ClubIS.CoreLayer.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ClubIS.DataAccessLayer
{
    public static class DataInitializer
    {
        private static readonly int ID_1 = 1;
        private static readonly int ID_2 = 2;
        private static readonly int ID_3 = 3;
        private static readonly int ID_4 = 4;
        private static readonly int ID_5 = 5;

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>()
            .HasData(new Address
            {
                Id = ID_1,
                UserId = ID_1,
                StreetAndNumber = "Pantoflová 16",
                City = "Brno",
                PostalCode = "62800"
            }, new Address
            {
                Id = ID_2,
                UserId = ID_2,
                StreetAndNumber = "Smrková 4",
                City = "Brno",
                PostalCode = "61300"
            });

            modelBuilder.Entity<MemberFee>()
            .HasData(new MemberFee
            {
                Id = ID_2,
                Name = "All Inclusive",
                Description = "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.",
                Amount = 0,
                MemberFeeType = MemberFeeType.All
            }, new MemberFee
            {
                Id = ID_1,
                Name = "Základ",
                Description = "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.",
                Amount = 100,
                MemberFeeType = MemberFeeType.Basic
            });

            var supervisor = new User
            {
                Id = ID_1,
                AccountId = ID_1,
                Firstname = "Matěj",
                Surname = "Perník",
                RegistrationNumber = "ZBM1108",
                Nationality = "Česká republika",
                Email = "tst2@eof.cz",
                Gender = Gender.Male,
                Licence = Licence.C,
                AccountState = AccountState.Active,
            };
            var supervised = new User
            {
                Id = ID_2,
                AccountId = ID_2,
                Firstname = "Kateřina",
                Surname = "Muflonová",
                RegistrationNumber = "ZMB9751",
                Nationality = "Česká republika",
                Email = "tst2@eob.cz",
                Gender = Gender.Female,
                Licence = Licence.A,
                AccountState = AccountState.Active,
            };
            modelBuilder.Entity<User>().HasData(supervisor, supervised);

            modelBuilder.Entity<Supervision>()
            .HasData(new Supervision
            {
                SupervisorUserId = ID_1,
                SupervisedUserId = ID_2,
                IsEntrySupervisionEnabled = true,
                IsFinanceSupervisionEnabled = true
            });

            modelBuilder.Entity<FinanceAccount>()
            .HasData(new FinanceAccount
            {
                Id = ID_1,
                CreditBalance = -1000
            });

            modelBuilder.Entity<FinanceAccount>()
            .HasData(new FinanceAccount
            {
                Id = ID_2,
                CreditBalance = 0
            });

            modelBuilder.Entity<SiCard>()
            .HasData(new SiCard
            {
                Id = ID_1,
                UserId = ID_1,
                Number = 8670103,
                IsDefault = true
            }, new SiCard
            {
                Id = ID_2,
                UserId = ID_2,
                Number = 464031,
                IsDefault = true
            });

            modelBuilder.Entity<News>()
            .HasData(new News
            {
                Id = ID_1,
                UserId = ID_1,
                Date = new DateTime(2020, 9, 30),
                Title = "test nadpisu",
                Text = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."
            });

            modelBuilder.Entity<Event>()
            .HasData(new Event
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

            modelBuilder.Entity<Event>()
            .HasData(new Event
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

            modelBuilder.Entity<EventDeadline>()
            .HasData(new EventDeadline
            {
                Id = ID_1,
                EventId = ID_1,
                Deadline = new DateTime(2021, 9, 1)
            });

            modelBuilder.Entity<EventDeadline>()
            .HasData(new EventDeadline
            {
                Id = ID_2,
                EventId = ID_2,
                Deadline = new DateTime(2021, 10, 1)
            }, new EventDeadline
            {
                Id = ID_3,
                EventId = ID_2,
                Deadline = new DateTime(2021, 10, 5)
            });

            modelBuilder.Entity<EventClassOption>()
            .HasData(new EventClassOption
            {
                Id = ID_1,
                EventId = ID_1,
                Name = "A"
            }, new EventClassOption
            {
                Id = ID_2,
                EventId = ID_1,
                Name = "B"
            });

            modelBuilder.Entity<EventClassOption>()
            .HasData(new EventClassOption
            {
                Id = ID_3,
                EventId = ID_2,
                Name = "D14"
            }, new EventClassOption
            {
                Id = ID_4,
                EventId = ID_2,
                Name = "D45"
            }, new EventClassOption
            {
                Id = ID_5,
                EventId = ID_2,
                Name = "H20"
            });

            modelBuilder.Entity<EventEntry>()
            .HasData(new EventEntry
            {
                Id = ID_1,
                UserId = ID_1,
                EventId = ID_1,
                Class = "A",
                SiCardNumber = 464031,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<EventEntry>()
            .HasData(new EventEntry
            {
                Id = ID_2,
                UserId = ID_2,
                EventId = ID_1,
                Class = "B",
                SiCardNumber = 8670103,
                HasClubAccommodation = true,
                HasClubTransport = true
            });

            modelBuilder.Entity<Payment>()
            .HasData(new Payment
            {
                Id = ID_1,
                ExecutorId = ID_1,
                SourceAccountId = ID_1,
                EventId = ID_1,
                CreditAmount = 1000,
                PaymentState = PaymentState.Ok
            });

            var hasher = new PasswordHasher<UserIdentity>();
            modelBuilder.Entity<UserIdentity>()
            .HasData(new UserIdentity
            {
                // matej
                Id = ID_1,
                UserName = "admin123",
                NormalizedUserName = "ADMIN123",
                PasswordHash = hasher.HashPassword(null, "admin123"),
                SecurityStamp = string.Empty
            }, new UserIdentity
            {
                // katka
                Id = ID_2,
                UserName = "user123",
                NormalizedUserName = "USER123",
                PasswordHash = hasher.HashPassword(null, "user123"),
                SecurityStamp = string.Empty
            });

            // make matej admin
            modelBuilder.Entity<IdentityUserRole<int>>()
            .HasData(new IdentityUserRole<int>
            {
                RoleId = 1,
                UserId = ID_1
            });
        }
    }
}