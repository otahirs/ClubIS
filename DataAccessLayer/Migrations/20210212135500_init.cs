using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("AspNetRoles", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoles", x => x.Id);
            });

            migrationBuilder.CreateTable("AspNetUsers", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedUserName = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                Email = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                NormalizedEmail = table.Column<string>("nvarchar(256)", maxLength: 256, nullable: true),
                EmailConfirmed = table.Column<bool>("bit", nullable: false),
                PasswordHash = table.Column<string>("nvarchar(max)", nullable: true),
                SecurityStamp = table.Column<string>("nvarchar(max)", nullable: true),
                ConcurrencyStamp = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumber = table.Column<string>("nvarchar(max)", nullable: true),
                PhoneNumberConfirmed = table.Column<bool>("bit", nullable: false),
                TwoFactorEnabled = table.Column<bool>("bit", nullable: false),
                LockoutEnd = table.Column<DateTimeOffset>("datetimeoffset", nullable: true),
                LockoutEnabled = table.Column<bool>("bit", nullable: false),
                AccessFailedCount = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUsers", x => x.Id);
            });

            migrationBuilder.CreateTable("Events", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                StartDate = table.Column<DateTime>("datetime2", nullable: false),
                EndDate = table.Column<DateTime>("datetime2", nullable: false),
                Name = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Place = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Organizer = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                AccommodationOption = table.Column<int>("int", nullable: false),
                TransportOption = table.Column<int>("int", nullable: false),
                Link = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Note = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true),
                Leader = table.Column<string>("nvarchar(max)", nullable: true),
                EventType = table.Column<int>("int", nullable: false),
                EventState = table.Column<int>("int", nullable: false),
                EventProperties = table.Column<int>("int", nullable: false),
                Entries = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Events", x => x.Id);
            });

            migrationBuilder.CreateTable("FinanceAccounts", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                CreditBalance = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_FinanceAccounts", x => x.Id);
            });

            migrationBuilder.CreateTable("MemberFees", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(20)", maxLength: 20, nullable: true),
                Description = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true),
                Amount = table.Column<int>("int", nullable: false),
                MemberFeeType = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_MemberFees", x => x.Id);
            });

            migrationBuilder.CreateTable("AspNetRoleClaims", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                RoleId = table.Column<int>("int", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                table.ForeignKey("FK_AspNetRoleClaims_AspNetRoles_RoleId", x => x.RoleId, "AspNetRoles", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("AspNetUserClaims", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                ClaimType = table.Column<string>("nvarchar(max)", nullable: true),
                ClaimValue = table.Column<string>("nvarchar(max)", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                table.ForeignKey("FK_AspNetUserClaims_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("AspNetUserLogins", table => new
            {
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderKey = table.Column<string>("nvarchar(450)", nullable: false),
                ProviderDisplayName = table.Column<string>("nvarchar(max)", nullable: true),
                UserId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserLogins", x => new
                {
                    x.LoginProvider,
                    x.ProviderKey
                });
                table.ForeignKey("FK_AspNetUserLogins_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("AspNetUserRoles", table => new
            {
                UserId = table.Column<int>("int", nullable: false),
                RoleId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserRoles", x => new
                {
                    x.UserId,
                    x.RoleId
                });
                table.ForeignKey("FK_AspNetUserRoles_AspNetRoles_RoleId", x => x.RoleId, "AspNetRoles", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_AspNetUserRoles_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("AspNetUserTokens", table => new
            {
                UserId = table.Column<int>("int", nullable: false),
                LoginProvider = table.Column<string>("nvarchar(450)", nullable: false),
                Name = table.Column<string>("nvarchar(450)", nullable: false),
                Value = table.Column<string>("nvarchar(max)", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_AspNetUserTokens", x => new
                {
                    x.UserId,
                    x.LoginProvider,
                    x.Name
                });
                table.ForeignKey("FK_AspNetUserTokens_AspNetUsers_UserId", x => x.UserId, "AspNetUsers", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("EventClassOption", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: true),
                EventId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_EventClassOption", x => x.Id);
                table.ForeignKey("FK_EventClassOption_Events_EventId", x => x.EventId, "Events", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("EventDeadline", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                Deadline = table.Column<DateTime>("datetime2", nullable: false),
                EventId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_EventDeadline", x => x.Id);
                table.ForeignKey("FK_EventDeadline_Events_EventId", x => x.EventId, "Events", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("EventStage", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                EventId = table.Column<int>("int", nullable: false),
                Date = table.Column<DateTime>("datetime2", maxLength: 50, nullable: false),
                Name = table.Column<string>("nvarchar(max)", nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_EventStage", x => x.Id);
                table.ForeignKey("FK_EventStage_Events_EventId", x => x.EventId, "Events", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("Users", table => new
            {
                Id = table.Column<int>("int", nullable: false),
                AccountId = table.Column<int>("int", nullable: false),
                FinanceSupervisorId = table.Column<int>("int", nullable: true),
                MemberFeeId = table.Column<int>("int", nullable: true),
                Firstname = table.Column<string>("nvarchar(20)", maxLength: 20, nullable: false),
                Surname = table.Column<string>("nvarchar(30)", maxLength: 30, nullable: false),
                RegistrationNumber = table.Column<string>("nvarchar(7)", maxLength: 7, nullable: false),
                DateOfBirth = table.Column<DateTime>("datetime2", nullable: true),
                Nationality = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Email = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Phone = table.Column<string>("nvarchar(25)", maxLength: 25, nullable: true),
                Gender = table.Column<int>("int", nullable: false),
                Licence = table.Column<int>("int", nullable: false),
                AccountState = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Users", x => x.Id);
                table.ForeignKey("FK_Users_FinanceAccounts_AccountId", x => x.AccountId, "FinanceAccounts", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_Users_MemberFees_MemberFeeId", x => x.MemberFeeId, "MemberFees", "Id", onDelete: ReferentialAction.Restrict);
                table.ForeignKey("FK_Users_Users_FinanceSupervisorId", x => x.FinanceSupervisorId, "Users", "Id", onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable("Address", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                StreetAndNumber = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                City = table.Column<string>("nvarchar(25)", maxLength: 25, nullable: true),
                PostalCode = table.Column<string>("nvarchar(6)", maxLength: 6, nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Address", x => x.Id);
                table.ForeignKey("FK_Address_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("EventEntries", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                EventId = table.Column<int>("int", nullable: false),
                Class = table.Column<string>("nvarchar(10)", maxLength: 10, nullable: true),
                HasClubAccommodation = table.Column<bool>("bit", nullable: false),
                HasClubTransport = table.Column<bool>("bit", nullable: false),
                NoteForClub = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true),
                NoteForOrganisator = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true),
                SiCardNumber = table.Column<int>("int", nullable: true),
                Status = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_EventEntries", x => x.Id);
                table.ForeignKey("FK_EventEntries_Events_EventId", x => x.EventId, "Events", "Id", onDelete: ReferentialAction.Cascade);
                table.ForeignKey("FK_EventEntries_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("News", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                Date = table.Column<DateTime>("datetime2", nullable: false),
                Title = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                Text = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_News", x => x.Id);
                table.ForeignKey("FK_News_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("Payments", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                ExecutorId = table.Column<int>("int", nullable: true),
                SourceAccountId = table.Column<int>("int", nullable: true),
                RecipientAccountId = table.Column<int>("int", nullable: true),
                EventId = table.Column<int>("int", nullable: true),
                Date = table.Column<DateTime>("datetime2", nullable: false),
                CreditAmount = table.Column<int>("int", nullable: false),
                Message = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true),
                PaymentState = table.Column<int>("int", nullable: false),
                StornoNote = table.Column<string>("nvarchar(255)", maxLength: 255, nullable: true)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_Payments", x => x.Id);
                table.ForeignKey("FK_Payments_Events_EventId", x => x.EventId, "Events", "Id", onDelete: ReferentialAction.Restrict);
                table.ForeignKey("FK_Payments_FinanceAccounts_RecipientAccountId", x => x.RecipientAccountId, "FinanceAccounts", "Id", onDelete: ReferentialAction.Restrict);
                table.ForeignKey("FK_Payments_FinanceAccounts_SourceAccountId", x => x.SourceAccountId, "FinanceAccounts", "Id", onDelete: ReferentialAction.Restrict);
                table.ForeignKey("FK_Payments_Users_ExecutorId", x => x.ExecutorId, "Users", "Id", onDelete: ReferentialAction.Restrict);
            });

            migrationBuilder.CreateTable("SiCard", table => new
            {
                Id = table.Column<int>("int", nullable: false).Annotation("SqlServer:Identity", "1, 1"),
                UserId = table.Column<int>("int", nullable: false),
                Number = table.Column<int>("int", nullable: false),
                IsDefault = table.Column<bool>("bit", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_SiCard", x => x.Id);
                table.ForeignKey("FK_SiCard_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("User_EntriesSupervisor", table => new
            {
                EntriesSupervisorId = table.Column<int>("int", nullable: false),
                UserId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_User_EntriesSupervisor", x => new
                {
                    x.EntriesSupervisorId,
                    x.UserId
                });
                table.ForeignKey("FK_User_EntriesSupervisor_Users_EntriesSupervisorId", x => x.EntriesSupervisorId, "Users", "Id", onDelete: ReferentialAction.Restrict);
                table.ForeignKey("FK_User_EntriesSupervisor_Users_UserId", x => x.UserId, "Users", "Id", onDelete: ReferentialAction.Cascade);
            });

            migrationBuilder.CreateTable("EvenEntry_EventStage", table => new
            {
                EventEntryId = table.Column<int>("int", nullable: false),
                EventStageId = table.Column<int>("int", nullable: false)
            }, constraints: table =>
            {
                table.PrimaryKey("PK_EvenEntry_EventStage", x => new
                {
                    x.EventEntryId,
                    x.EventStageId
                });
                table.ForeignKey("FK_EvenEntry_EventStage_EventEntries_EventEntryId", x => x.EventEntryId, "EventEntries", "Id");
                table.ForeignKey("FK_EvenEntry_EventStage_EventStage_EventStageId", x => x.EventStageId, "EventStage", "Id");
            });

            migrationBuilder.InsertData("AspNetRoles", new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"}, new object[,] {{1, "3b7764b1-ccab-4c02-8e1e-10e62574c83c", "admin", "ADMIN"}, {2, "0115ca95-4989-4455-b065-88e7cd5e6a2e", "entries", "ENTRIES"}, {3, "d1aed71f-7301-4433-9b13-bd37306b81b1", "events", "EVENTS"}, {4, "cb700a47-dc0f-4d8d-82ba-4d71db9bfa31", "finance", "FINANCE"}, {5, "429f9368-ff5c-43e5-b021-888ff9ca1d1b", "news", "NEWS"}, {6, "08c86235-da40-49bd-aae7-210b8f10d264", "users", "USERS"}});

            migrationBuilder.InsertData("AspNetUsers", new[] {"Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName"}, new object[,] {{1, 0, "549207d7-d987-4bc8-90d1-4d491e60979e", null, false, false, null, null, "MATEJ", "AQAAAAEAACcQAAAAEKec1Afnjr0ZqT69v9wvcqO1IeDFXlmGMnxjLe1CV7/4h5UFDjlRsl8YIGIc9nsIUw==", null, false, "", false, "matej"}, {2, 0, "f6691153-db87-4b70-8d7a-c87190018e59", null, false, false, null, null, "KATKA", "AQAAAAEAACcQAAAAEIYxEcVgnxlvgWhUbNQcsSA1Bt9SNT/8wkeMrV2oqe0xvXJ5/oido7+NoYo9MWlHbw==", null, false, "", false, "katka"}});

            migrationBuilder.InsertData("Events", new[] {"Id", "AccommodationOption", "EndDate", "Entries", "EventProperties", "EventState", "EventType", "Leader", "Link", "Name", "Note", "Organizer", "Place", "StartDate", "TransportOption"}, new object[,] {{1, 2, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 2, null, "mcr2020.obopava.cz", "Soustředění Vysočina", null, "OB ZAM", "Sklené", new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1}, {2, 2, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 0, null, "mcr2020.obopava.cz", "9. JML  klasická trať", null, "OB ZAM", "Jilemnice", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1}});

            migrationBuilder.InsertData("FinanceAccounts", new[] {"Id", "CreditBalance"}, new object[,] {{1, -1000}, {2, 0}});

            migrationBuilder.InsertData("MemberFees", new[] {"Id", "Amount", "Description", "MemberFeeType", "Name"}, new object[,] {{2, 0, "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.", 4, "All Inclusive"}, {1, 100, "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.", 1, "Základ"}});

            migrationBuilder.InsertData("AspNetUserRoles", new[] {"RoleId", "UserId"}, new object[] {1, 1});

            migrationBuilder.InsertData("EventClassOption", new[] {"Id", "EventId", "Name"}, new object[,] {{1, 1, "A"}, {2, 1, "B"}, {3, 2, "A"}, {4, 2, "B"}, {5, 2, "H20"}});

            migrationBuilder.InsertData("EventDeadline", new[] {"Id", "Deadline", "EventId"}, new object[,] {{1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1}, {2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2}, {3, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2}});

            migrationBuilder.InsertData("Users", new[] {"Id", "AccountId", "AccountState", "DateOfBirth", "Email", "FinanceSupervisorId", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname"}, new object[] {1, 1, 0, null, "tst2@eof.cz", null, "Matěj", 0, 0, null, "Česká republika", null, "***REMOVED***", "***REMOVED***"});

            migrationBuilder.InsertData("Address", new[] {"Id", "City", "PostalCode", "StreetAndNumber", "UserId"}, new object[] {1, "Brno", "***REMOVED***", "***REMOVED***", 1});

            migrationBuilder.InsertData("EventEntries", new[] {"Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId"}, new object[] {1, "A", 1, true, true, null, null, ***REMOVED***, 0, 1});

            migrationBuilder.InsertData("News", new[] {"Id", "Date", "Text", "Title", "UserId"}, new object[] {1, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1111111111111111111111111111111111111111111111111111111111111111111111111111111", "test nadpisu", 1});

            migrationBuilder.InsertData("Payments", new[] {"Id", "CreditAmount", "Date", "EventId", "ExecutorId", "Message", "PaymentState", "RecipientAccountId", "SourceAccountId", "StornoNote"}, new object[] {1, 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 0, null, 1, null});

            migrationBuilder.InsertData("SiCard", new[] {"Id", "IsDefault", "Number", "UserId"}, new object[] {1, true, ***REMOVED***, 1});

            migrationBuilder.InsertData("Users", new[] {"Id", "AccountId", "AccountState", "DateOfBirth", "Email", "FinanceSupervisorId", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname"}, new object[] {2, 2, 0, null, "tst2@eob.cz", 1, "Kateřina", 1, 2, null, "Česká republika", null, "***REMOVED***", "***REMOVED***"});

            migrationBuilder.InsertData("Address", new[] {"Id", "City", "PostalCode", "StreetAndNumber", "UserId"}, new object[] {2, "***REMOVED***", "***REMOVED***", null, 2});

            migrationBuilder.InsertData("EventEntries", new[] {"Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId"}, new object[] {2, "H20", 1, true, true, null, null, ***REMOVED***, 0, 2});

            migrationBuilder.InsertData("SiCard", new[] {"Id", "IsDefault", "Number", "UserId"}, new object[] {2, true, ***REMOVED***, 2});

            migrationBuilder.InsertData("User_EntriesSupervisor", new[] {"EntriesSupervisorId", "UserId"}, new object[] {2, 1});

            migrationBuilder.CreateIndex("IX_Address_UserId", "Address", "UserId", unique: true);

            migrationBuilder.CreateIndex("IX_AspNetRoleClaims_RoleId", "AspNetRoleClaims", "RoleId");

            migrationBuilder.CreateIndex("RoleNameIndex", "AspNetRoles", "NormalizedName", unique: true, filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex("IX_AspNetUserClaims_UserId", "AspNetUserClaims", "UserId");

            migrationBuilder.CreateIndex("IX_AspNetUserLogins_UserId", "AspNetUserLogins", "UserId");

            migrationBuilder.CreateIndex("IX_AspNetUserRoles_RoleId", "AspNetUserRoles", "RoleId");

            migrationBuilder.CreateIndex("EmailIndex", "AspNetUsers", "NormalizedEmail");

            migrationBuilder.CreateIndex("UserNameIndex", "AspNetUsers", "NormalizedUserName", unique: true, filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex("IX_EvenEntry_EventStage_EventStageId", "EvenEntry_EventStage", "EventStageId");

            migrationBuilder.CreateIndex("IX_EventClassOption_EventId", "EventClassOption", "EventId");

            migrationBuilder.CreateIndex("IX_EventDeadline_EventId", "EventDeadline", "EventId");

            migrationBuilder.CreateIndex("IX_EventEntries_EventId", "EventEntries", "EventId");

            migrationBuilder.CreateIndex("IX_EventEntries_UserId", "EventEntries", "UserId");

            migrationBuilder.CreateIndex("IX_EventStage_EventId", "EventStage", "EventId");

            migrationBuilder.CreateIndex("IX_News_UserId", "News", "UserId");

            migrationBuilder.CreateIndex("IX_Payments_EventId", "Payments", "EventId");

            migrationBuilder.CreateIndex("IX_Payments_ExecutorId", "Payments", "ExecutorId");

            migrationBuilder.CreateIndex("IX_Payments_RecipientAccountId", "Payments", "RecipientAccountId");

            migrationBuilder.CreateIndex("IX_Payments_SourceAccountId", "Payments", "SourceAccountId");

            migrationBuilder.CreateIndex("IX_SiCard_UserId", "SiCard", "UserId");

            migrationBuilder.CreateIndex("IX_User_EntriesSupervisor_UserId", "User_EntriesSupervisor", "UserId");

            migrationBuilder.CreateIndex("IX_Users_AccountId", "Users", "AccountId", unique: true);

            migrationBuilder.CreateIndex("IX_Users_FinanceSupervisorId", "Users", "FinanceSupervisorId");

            migrationBuilder.CreateIndex("IX_Users_MemberFeeId", "Users", "MemberFeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("Address");

            migrationBuilder.DropTable("AspNetRoleClaims");

            migrationBuilder.DropTable("AspNetUserClaims");

            migrationBuilder.DropTable("AspNetUserLogins");

            migrationBuilder.DropTable("AspNetUserRoles");

            migrationBuilder.DropTable("AspNetUserTokens");

            migrationBuilder.DropTable("EvenEntry_EventStage");

            migrationBuilder.DropTable("EventClassOption");

            migrationBuilder.DropTable("EventDeadline");

            migrationBuilder.DropTable("News");

            migrationBuilder.DropTable("Payments");

            migrationBuilder.DropTable("SiCard");

            migrationBuilder.DropTable("User_EntriesSupervisor");

            migrationBuilder.DropTable("AspNetRoles");

            migrationBuilder.DropTable("AspNetUsers");

            migrationBuilder.DropTable("EventEntries");

            migrationBuilder.DropTable("EventStage");

            migrationBuilder.DropTable("Users");

            migrationBuilder.DropTable("Events");

            migrationBuilder.DropTable("FinanceAccounts");

            migrationBuilder.DropTable("MemberFees");
        }
    }
}