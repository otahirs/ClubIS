using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ClubIS.WebAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Place = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Organizer = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    AccommodationOption = table.Column<int>(type: "integer", nullable: false),
                    TransportOption = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Note = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Leader = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    EventState = table.Column<int>(type: "integer", nullable: false),
                    EventProperties = table.Column<int>(type: "integer", nullable: false),
                    Entries = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreditBalance = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Description = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    Amount = table.Column<int>(type: "integer", nullable: false),
                    MemberFeeType = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false)
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
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Deadline = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false),
                    AccountId = table.Column<int>(type: "integer", nullable: false),
                    MemberFeeId = table.Column<int>(type: "integer", nullable: true),
                    Firstname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Surname = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    RegistrationNumber = table.Column<string>(type: "character varying(7)", maxLength: 7, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Nationality = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    Gender = table.Column<int>(type: "integer", nullable: false),
                    Licence = table.Column<int>(type: "integer", nullable: false),
                    AccountState = table.Column<int>(type: "integer", nullable: false)
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
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    StreetAndNumber = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    City = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(6)", maxLength: 6, nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    EventId = table.Column<int>(type: "integer", nullable: false),
                    Class = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    HasClubAccommodation = table.Column<bool>(type: "boolean", nullable: false),
                    HasClubTransport = table.Column<bool>(type: "boolean", nullable: false),
                    NoteForClub = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    NoteForOrganisator = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    SiCardNumber = table.Column<int>(type: "integer", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Title = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Text = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExecutorId = table.Column<int>(type: "integer", nullable: true),
                    SourceAccountId = table.Column<int>(type: "integer", nullable: true),
                    RecipientAccountId = table.Column<int>(type: "integer", nullable: true),
                    EventId = table.Column<int>(type: "integer", nullable: true),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreditAmount = table.Column<int>(type: "integer", nullable: false),
                    Message = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true),
                    PaymentState = table.Column<int>(type: "integer", nullable: false),
                    StornoNote = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payments_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_FinanceAccounts_RecipientAccountId",
                        column: x => x.RecipientAccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_FinanceAccounts_SourceAccountId",
                        column: x => x.SourceAccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payments_Users_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SiCard",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    Number = table.Column<int>(type: "integer", nullable: false),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false)
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
                name: "Supervision",
                columns: table => new
                {
                    SupervisorUserId = table.Column<int>(type: "integer", nullable: false),
                    SupervisedUserId = table.Column<int>(type: "integer", nullable: false),
                    IsEntrySupervisionEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    IsFinanceSupervisionEnabled = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supervision", x => new { x.SupervisedUserId, x.SupervisorUserId });
                    table.ForeignKey(
                        name: "FK_Supervision_Users_SupervisedUserId",
                        column: x => x.SupervisedUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Supervision_Users_SupervisorUserId",
                        column: x => x.SupervisorUserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvenEntry_EventStage",
                columns: table => new
                {
                    EventEntryId = table.Column<int>(type: "integer", nullable: false),
                    EventStageId = table.Column<int>(type: "integer", nullable: false)
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
                values: new object[,]
                {
                    { 1, "e9872454-a9ac-4263-9b57-090c70f0ee13", "admin", "ADMIN" },
                    { 2, "43f99126-d4c7-4f56-9e15-86a052a877c0", "entries", "ENTRIES" },
                    { 3, "95f469f3-c93c-4d20-b96e-345a69263b2c", "events", "EVENTS" },
                    { 4, "61235455-4b69-4040-a1fa-255a1570c3fe", "finance", "FINANCE" },
                    { 5, "2fd3f196-0c23-4891-bb2b-fa95ff30dcb4", "news", "NEWS" },
                    { 6, "49d0c106-eceb-49f3-9d71-29755005c64a", "users", "USERS" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "68187122-4da8-4855-9b29-fcc80653b21a", null, false, false, null, null, "ADMIN123", "AQAAAAEAACcQAAAAEMyJhyjZAb5/kq9AcwQnfHopfAwRf2WdApY5UhjUuEvmkKvi/w6ZkFtyjV7qSdJtsw==", null, false, "", false, "admin123" },
                    { 2, 0, "d097b095-eb53-4c79-aac5-a72c08a66bef", null, false, false, null, null, "USER123", "AQAAAAEAACcQAAAAEMNwuzDCeTufCvMaTC7hP3uyaKoo88bBmAqiA+RuThLOok7kLkmw2krjwDQYJDXe2w==", null, false, "", false, "user123" }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AccommodationOption", "EndDate", "Entries", "EventProperties", "EventState", "EventType", "Leader", "Link", "Name", "Note", "Organizer", "Place", "StartDate", "TransportOption" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 2, null, "mcr2020.obopava.cz", "Soustředění Vysočina", null, "OB ZAM", "Sklené", new DateTime(2021, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 0, 0, null, "mcr2020.obopava.cz", "9. JML  klasická trať", null, "OB ZAM", "Jilemnice", new DateTime(2021, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "FinanceAccounts",
                columns: new[] { "Id", "CreditBalance" },
                values: new object[,]
                {
                    { 1, -1000 },
                    { 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "MemberFees",
                columns: new[] { "Id", "Amount", "Description", "MemberFeeType", "Name" },
                values: new object[,]
                {
                    { 1, 100, "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.", 1, "Základ" },
                    { 2, 0, "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.", 4, "All Inclusive" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A" },
                    { 2, 1, "B" },
                    { 3, 2, "D14" },
                    { 4, 2, "D45" },
                    { 5, 2, "H20" }
                });

            migrationBuilder.InsertData(
                table: "EventDeadline",
                columns: new[] { "Id", "Deadline", "EventId" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2021, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2021, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "AccountState", "DateOfBirth", "Email", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname" },
                values: new object[,]
                {
                    { 1, 1, 0, null, "tst2@eof.cz", "Matěj", 0, 0, null, "Česká republika", null, "ZBM1108", "Perník" },
                    { 2, 2, 0, null, "tst2@eob.cz", "Kateřina", 1, 2, null, "Česká republika", null, "ZMB9751", "Muflonová" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "StreetAndNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "Brno", "62800", "Pantoflová 16", 1 },
                    { 2, "Brno", "61300", "Smrková 4", 2 }
                });

            migrationBuilder.InsertData(
                table: "EventEntries",
                columns: new[] { "Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "A", 1, true, true, null, null, 464031, 0, 1 },
                    { 2, "B", 1, true, true, null, null, 8670103, 0, 2 }
                });

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
                values: new object[,]
                {
                    { 1, true, 8670103, 1 },
                    { 2, true, 464031, 2 }
                });

            migrationBuilder.InsertData(
                table: "Supervision",
                columns: new[] { "SupervisedUserId", "SupervisorUserId", "IsEntrySupervisionEnabled", "IsFinanceSupervisionEnabled" },
                values: new object[] { 2, 1, true, true });

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
                name: "IX_Supervision_SupervisorUserId",
                table: "Supervision",
                column: "SupervisorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

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
                name: "Supervision");

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
