using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.Migrations.SQLite.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Place = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Organizer = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    AccommodationOption = table.Column<int>(type: "INTEGER", nullable: false),
                    TransportOption = table.Column<int>(type: "INTEGER", nullable: false),
                    Link = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Leader = table.Column<string>(type: "TEXT", nullable: true),
                    EventType = table.Column<int>(type: "INTEGER", nullable: false),
                    EventState = table.Column<int>(type: "INTEGER", nullable: false),
                    EventProperties = table.Column<int>(type: "INTEGER", nullable: false),
                    Entries = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreditBalance = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    Amount = table.Column<int>(type: "INTEGER", nullable: false),
                    MemberFeeType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RoleId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventClassOption",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventClassOption", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventClassOption_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventDeadline",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Deadline = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDeadline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventDeadline_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventStage_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    FinanceSupervisorId = table.Column<int>(type: "INTEGER", nullable: true),
                    MemberFeeId = table.Column<int>(type: "INTEGER", nullable: true),
                    Firstname = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "TEXT", maxLength: 7, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Nationality = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    Gender = table.Column<int>(type: "INTEGER", nullable: false),
                    Licence = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountState = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_FinanceAccounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_MemberFees_MemberFeeId",
                        column: x => x.MemberFeeId,
                        principalTable: "MemberFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_Users_FinanceSupervisorId",
                        column: x => x.FinanceSupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    StreetAndNumber = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "TEXT", maxLength: 25, nullable: true),
                    PostalCode = table.Column<string>(type: "TEXT", maxLength: 6, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    Class = table.Column<string>(type: "TEXT", maxLength: 10, nullable: true),
                    HasClubAccommodation = table.Column<bool>(type: "INTEGER", nullable: false),
                    HasClubTransport = table.Column<bool>(type: "INTEGER", nullable: false),
                    NoteForClub = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    NoteForOrganisator = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    SiCardNumber = table.Column<int>(type: "INTEGER", nullable: true),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEntries_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventEntries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    Text = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExecutorId = table.Column<int>(type: "INTEGER", nullable: true),
                    SourceAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    RecipientAccountId = table.Column<int>(type: "INTEGER", nullable: true),
                    EventId = table.Column<int>(type: "INTEGER", nullable: true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    CreditAmount = table.Column<int>(type: "INTEGER", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true),
                    PaymentState = table.Column<int>(type: "INTEGER", nullable: false),
                    StornoNote = table.Column<string>(type: "TEXT", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_FinanceAccounts_RecipientAccountId",
                        column: x => x.RecipientAccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_FinanceAccounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payments_Users_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SiCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Number = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDefault = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiCard", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SiCard_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User_EntriesSupervisor",
                columns: table => new
                {
                    EntriesSupervisorId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_EntriesSupervisor", x => new { x.EntriesSupervisorId, x.UserId });
                    table.ForeignKey(
                        name: "FK_User_EntriesSupervisor_Users_EntriesSupervisorId",
                        column: x => x.EntriesSupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_EntriesSupervisor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EvenEntry_EventStage",
                columns: table => new
                {
                    EventEntryId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventStageId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvenEntry_EventStage", x => new { x.EventEntryId, x.EventStageId });
                    table.ForeignKey(
                        name: "FK_EvenEntry_EventStage_EventEntries_EventEntryId",
                        column: x => x.EventEntryId,
                        principalTable: "EventEntries",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EvenEntry_EventStage_EventStage_EventStageId",
                        column: x => x.EventStageId,
                        principalTable: "EventStage",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "53b2e2cd-bc99-46ad-a8b3-63849c4a84a0", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "bd3237ea-db65-451e-b9ed-660cc0bc133a", "entries", "ENTRIES" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "84f104b2-30f7-48b2-98d9-c0a2f82fea95", "events", "EVENTS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 4, "63ee3670-a95c-4976-b4f1-22e95494cb7f", "finance", "FINANCE" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 5, "1dd7bb1d-13d6-4e86-9df2-bd1770c47f7a", "news", "NEWS" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 6, "0d514b4e-32b6-4a49-8dce-fe43625ae103", "users", "USERS" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 1, 0, "3358c6d8-0dde-42d5-94c6-bff4e3968cda", null, false, false, null, null, "ADMIN123", "AQAAAAEAACcQAAAAEPj9XP6T3a/P8NovcANlCHFJry8T+gGFLgUXoV90I6JZcmU3B1GfjxC/C5tR74GtDA==", null, false, "", false, "admin123" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { 2, 0, "d39b63ee-8ac0-4fec-9c9e-1fb099b85db8", null, false, false, null, null, "USER123", "AQAAAAEAACcQAAAAEEz9ls4ZKtmdYc6PvQRY3n/rREW18MDbzI8CjZljEupC0qR+ba+7G99lMG4RlqekEQ==", null, false, "", false, "user123" });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AccommodationOption", "EndDate", "Entries", "EventProperties", "EventState", "EventType", "Leader", "Link", "Name", "Note", "Organizer", "Place", "StartDate", "TransportOption" },
                values: new object[] { 1, 2, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 2, null, "mcr2020.obopava.cz", "Soustředění Vysočina", null, "OB ZAM", "Sklené", new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AccommodationOption", "EndDate", "Entries", "EventProperties", "EventState", "EventType", "Leader", "Link", "Name", "Note", "Organizer", "Place", "StartDate", "TransportOption" },
                values: new object[] { 2, 2, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 0, null, "mcr2020.obopava.cz", "9. JML  klasická trať", null, "OB ZAM", "Jilemnice", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "FinanceAccounts",
                columns: new[] { "Id", "CreditBalance" },
                values: new object[] { 1, -1000 });

            migrationBuilder.InsertData(
                table: "FinanceAccounts",
                columns: new[] { "Id", "CreditBalance" },
                values: new object[] { 2, 0 });

            migrationBuilder.InsertData(
                table: "MemberFees",
                columns: new[] { "Id", "Amount", "Description", "MemberFeeType", "Name" },
                values: new object[] { 2, 0, "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.", 4, "All Inclusive" });

            migrationBuilder.InsertData(
                table: "MemberFees",
                columns: new[] { "Id", "Amount", "Description", "MemberFeeType", "Name" },
                values: new object[] { 1, 100, "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.", 1, "Základ" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[] { 1, 1, "A" });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[] { 2, 1, "B" });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[] { 3, 2, "D14" });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[] { 4, 2, "D45" });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[] { 5, 2, "H20" });

            migrationBuilder.InsertData(
                table: "EventDeadline",
                columns: new[] { "Id", "Deadline", "EventId" },
                values: new object[] { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "EventDeadline",
                columns: new[] { "Id", "Deadline", "EventId" },
                values: new object[] { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "EventDeadline",
                columns: new[] { "Id", "Deadline", "EventId" },
                values: new object[] { 3, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "AccountState", "DateOfBirth", "Email", "FinanceSupervisorId", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname" },
                values: new object[] { 1, 1, 0, null, "tst2@eof.cz", null, "Matěj", 0, 0, null, "Česká republika", null, "ZBM1108", "Perník" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "StreetAndNumber", "UserId" },
                values: new object[] { 1, "Brno", "62800", "Pantoflová 16", 1 });

            migrationBuilder.InsertData(
                table: "EventEntries",
                columns: new[] { "Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId" },
                values: new object[] { 1, "A", 1, true, true, null, null, 464031, 0, 1 });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Text", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++.", "test nadpisu", 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreditAmount", "Date", "EventId", "ExecutorId", "Message", "PaymentState", "RecipientAccountId", "SourceAccountId", "StornoNote" },
                values: new object[] { 1, 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 0, null, 1, null });

            migrationBuilder.InsertData(
                table: "SiCard",
                columns: new[] { "Id", "IsDefault", "Number", "UserId" },
                values: new object[] { 1, true, 8670103, 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "AccountState", "DateOfBirth", "Email", "FinanceSupervisorId", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname" },
                values: new object[] { 2, 2, 0, null, "tst2@eob.cz", 1, "Kateřina", 1, 2, null, "Česká republika", null, "ZMB9751", "Muflonová" });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "StreetAndNumber", "UserId" },
                values: new object[] { 2, "Brno", "61300", "Smrková 4", 2 });

            migrationBuilder.InsertData(
                table: "EventEntries",
                columns: new[] { "Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId" },
                values: new object[] { 2, "B", 1, true, true, null, null, 8670103, 0, 2 });

            migrationBuilder.InsertData(
                table: "SiCard",
                columns: new[] { "Id", "IsDefault", "Number", "UserId" },
                values: new object[] { 2, true, 464031, 2 });

            migrationBuilder.InsertData(
                table: "User_EntriesSupervisor",
                columns: new[] { "EntriesSupervisorId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EvenEntry_EventStage_EventStageId",
                table: "EvenEntry_EventStage",
                column: "EventStageId");

            migrationBuilder.CreateIndex(
                name: "IX_EventClassOption_EventId",
                table: "EventClassOption",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventDeadline_EventId",
                table: "EventDeadline",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntries_EventId",
                table: "EventEntries",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventEntries_UserId",
                table: "EventEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStage_EventId",
                table: "EventStage",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EventId",
                table: "Payments",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_ExecutorId",
                table: "Payments",
                column: "ExecutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RecipientAccountId",
                table: "Payments",
                column: "RecipientAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SourceAccountId",
                table: "Payments",
                column: "SourceAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_SiCard_UserId",
                table: "SiCard",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_User_EntriesSupervisor_UserId",
                table: "User_EntriesSupervisor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FinanceSupervisorId",
                table: "Users",
                column: "FinanceSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_MemberFeeId",
                table: "Users",
                column: "MemberFeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EvenEntry_EventStage");

            migrationBuilder.DropTable(
                name: "EventClassOption");

            migrationBuilder.DropTable(
                name: "EventDeadline");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SiCard");

            migrationBuilder.DropTable(
                name: "User_EntriesSupervisor");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "EventEntries");

            migrationBuilder.DropTable(
                name: "EventStage");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "FinanceAccounts");

            migrationBuilder.DropTable(
                name: "MemberFees");
        }
    }
}
