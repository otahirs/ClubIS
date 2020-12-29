﻿// <auto-generated />
using System;
using ClubIS.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClubIS.DataAccessLayer.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(6)")
                        .HasMaxLength(6);

                    b.Property<string>("StreetAndNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Brno",
                            PostalCode = "***REMOVED***",
                            StreetAndNumber = "***REMOVED***",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            City = "Brno - Horní Heršpice",
                            PostalCode = "***REMOVED***",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccommodationOption")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Entries")
                        .HasColumnType("int");

                    b.Property<int>("EventProperties")
                        .HasColumnType("int");

                    b.Property<int>("EventState")
                        .HasColumnType("int");

                    b.Property<int>("EventType")
                        .HasColumnType("int");

                    b.Property<string>("Leader")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Organizer")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Place")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("TransportOption")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Events");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccommodationOption = 2,
                            EndDate = new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entries = 0,
                            EventProperties = 16,
                            EventState = 2,
                            EventType = 2,
                            Link = "mcr2020.obopava.cz",
                            Name = "Soustředění Vysočina",
                            Organizer = "OB ZAM",
                            Place = "Sklené",
                            StartDate = new DateTime(2020, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransportOption = 1
                        },
                        new
                        {
                            Id = 2,
                            AccommodationOption = 2,
                            EndDate = new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Entries = 0,
                            EventProperties = 16,
                            EventState = 2,
                            EventType = 0,
                            Link = "mcr2020.obopava.cz",
                            Name = "9. JML - klasická trať",
                            Organizer = "OB ZAM",
                            Place = "Jilemnice",
                            StartDate = new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            TransportOption = 1
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventClassOption", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventClassOption");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EventId = 1,
                            Name = "A"
                        },
                        new
                        {
                            Id = 2,
                            EventId = 1,
                            Name = "B"
                        },
                        new
                        {
                            Id = 3,
                            EventId = 2,
                            Name = "A"
                        },
                        new
                        {
                            Id = 4,
                            EventId = 2,
                            Name = "B"
                        },
                        new
                        {
                            Id = 5,
                            EventId = 2,
                            Name = "H20"
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventDeadline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventDeadline");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventId = 1
                        },
                        new
                        {
                            Id = 2,
                            Deadline = new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventId = 2
                        },
                        new
                        {
                            Id = 3,
                            Deadline = new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventId = 2
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventEnteredStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EventEntryId")
                        .HasColumnType("int");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventEntryId");

                    b.ToTable("EventEnteredStage");
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Class")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<bool>("HasClubAccommodation")
                        .HasColumnType("bit");

                    b.Property<bool>("HasClubTransport")
                        .HasColumnType("bit");

                    b.Property<string>("NoteForClub")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("NoteForOrganisator")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int?>("SiCardNumber")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventEntries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Class = "A",
                            EventId = 1,
                            HasClubAccommodation = true,
                            HasClubTransport = true,
                            SiCardNumber = ***REMOVED***,
                            Status = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Class = "H20",
                            EventId = 2,
                            HasClubAccommodation = true,
                            HasClubTransport = true,
                            SiCardNumber = ***REMOVED***,
                            Status = 0,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventStage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasMaxLength(50);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("EventStage");
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.FinanceAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditBalance")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("FinanceAccounts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreditBalance = 0
                        },
                        new
                        {
                            Id = 2,
                            CreditBalance = 0
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.MemberFee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("MemberFeeType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.ToTable("MemberFees");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            Amount = 0,
                            Description = "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.",
                            MemberFeeType = 4,
                            Name = "All Inclusive"
                        },
                        new
                        {
                            Id = 1,
                            Amount = 100,
                            Description = "Nikam nejezdím nebo málo - veškeré závody se strhávají z osobního vkladu.",
                            MemberFeeType = 1,
                            Name = "Základ"
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("News");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Text = "1111111111111111111111111111111111111111111111111111111111111111111111111111111",
                            Title = "test nadpisu",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreditAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("ExecutorId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.Property<int>("PaymentState")
                        .HasColumnType("int");

                    b.Property<int?>("RecipientAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("RecipientUserId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceAccountId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceUserId")
                        .HasColumnType("int");

                    b.Property<string>("StornoNote")
                        .HasColumnType("nvarchar(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("ExecutorId");

                    b.HasIndex("RecipientAccountId");

                    b.HasIndex("RecipientUserId");

                    b.HasIndex("SourceAccountId");

                    b.HasIndex("SourceUserId");

                    b.ToTable("Payments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreditAmount = 1000,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EventId = 1,
                            ExecutorId = 1,
                            PaymentState = 0,
                            RecipientAccountId = 2,
                            SourceAccountId = 1
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.SiCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDefault")
                        .HasColumnType("bit");

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SiCard");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsDefault = true,
                            Number = ***REMOVED***,
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            IsDefault = true,
                            Number = ***REMOVED***,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("AccountState")
                        .HasColumnType("int");

                    b.Property<int>("BillingAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<int>("Licence")
                        .HasColumnType("int");

                    b.Property<int?>("MemberFeeId")
                        .HasColumnType("int");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(25)")
                        .HasMaxLength(25);

                    b.Property<string>("RegistrationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(7)")
                        .HasMaxLength(7);

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.HasIndex("BillingAccountId");

                    b.HasIndex("MemberFeeId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 2,
                            AccountState = 3,
                            BillingAccountId = 1,
                            Email = "tst2@eof.cz",
                            Firstname = "Matěj",
                            Gender = 0,
                            Licence = 0,
                            Nationality = "Česká republika",
                            RegistrationNumber = "***REMOVED***",
                            Surname = "***REMOVED***"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1,
                            AccountState = 0,
                            BillingAccountId = 1,
                            Email = "tst2@eob.cz",
                            Firstname = "Kateřina",
                            Gender = 1,
                            Licence = 2,
                            Nationality = "Česká republika",
                            RegistrationNumber = "***REMOVED***",
                            Surname = "***REMOVED***"
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.User_EntriesSupervisor", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("EntriesSupervisorId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "EntriesSupervisorId");

                    b.HasIndex("EntriesSupervisorId");

                    b.ToTable("User_EntriesSupervisor");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            EntriesSupervisorId = 1
                        });
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.Address", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.User", "User")
                        .WithOne("Address")
                        .HasForeignKey("ClubIS.CoreLayer.Entities.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventClassOption", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.Event", null)
                        .WithMany("ClassOptions")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventDeadline", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.Event", null)
                        .WithMany("Deadlines")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventEnteredStage", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.EventEntry", null)
                        .WithMany("EnteredStages")
                        .HasForeignKey("EventEntryId");
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventEntry", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubIS.CoreLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.EventStage", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.Event", null)
                        .WithMany("EventStages")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.News", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.Payment", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("ClubIS.CoreLayer.Entities.User", "Executor")
                        .WithMany()
                        .HasForeignKey("ExecutorId");

                    b.HasOne("ClubIS.CoreLayer.Entities.FinanceAccount", "RecipientAccount")
                        .WithMany()
                        .HasForeignKey("RecipientAccountId");

                    b.HasOne("ClubIS.CoreLayer.Entities.User", "RecipientUser")
                        .WithMany()
                        .HasForeignKey("RecipientUserId");

                    b.HasOne("ClubIS.CoreLayer.Entities.FinanceAccount", "SourceAccount")
                        .WithMany()
                        .HasForeignKey("SourceAccountId");

                    b.HasOne("ClubIS.CoreLayer.Entities.User", "SourceUser")
                        .WithMany()
                        .HasForeignKey("SourceUserId");
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.SiCard", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.User", "User")
                        .WithMany("SiCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.User", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.FinanceAccount", "Account")
                        .WithOne("Owner")
                        .HasForeignKey("ClubIS.CoreLayer.Entities.User", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ClubIS.CoreLayer.Entities.FinanceAccount", "BillingAccount")
                        .WithMany()
                        .HasForeignKey("BillingAccountId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClubIS.CoreLayer.Entities.MemberFee", "MemberFee")
                        .WithMany()
                        .HasForeignKey("MemberFeeId");
                });

            modelBuilder.Entity("ClubIS.CoreLayer.Entities.User_EntriesSupervisor", b =>
                {
                    b.HasOne("ClubIS.CoreLayer.Entities.User", "EntriesSupervisor")
                        .WithMany("EntriesSupervisedUsers")
                        .HasForeignKey("EntriesSupervisorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ClubIS.CoreLayer.Entities.User", "User")
                        .WithMany("EntriesSupervisors")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
