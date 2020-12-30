using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Place = table.Column<string>(maxLength: 50, nullable: true),
                    Organizer = table.Column<string>(maxLength: 50, nullable: true),
                    AccommodationOption = table.Column<int>(nullable: false),
                    TransportOption = table.Column<int>(nullable: false),
                    Link = table.Column<string>(maxLength: 50, nullable: true),
                    Note = table.Column<string>(maxLength: 255, nullable: true),
                    Leader = table.Column<string>(nullable: true),
                    EventType = table.Column<int>(nullable: false),
                    EventState = table.Column<int>(nullable: false),
                    EventProperties = table.Column<int>(nullable: false),
                    Entries = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FinanceAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditBalance = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MemberFees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 20, nullable: true),
                    Description = table.Column<string>(maxLength: 255, nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    MemberFeeType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MemberFees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventClassOption",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EventId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deadline = table.Column<DateTime>(nullable: false),
                    EventId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(maxLength: 50, nullable: false),
                    Name = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountId = table.Column<int>(nullable: false),
                    BillingAccountId = table.Column<int>(nullable: false),
                    MemberFeeId = table.Column<int>(nullable: true),
                    Firstname = table.Column<string>(maxLength: 20, nullable: false),
                    Surname = table.Column<string>(maxLength: 30, nullable: false),
                    RegistrationNumber = table.Column<string>(maxLength: 7, nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: true),
                    Nationality = table.Column<string>(maxLength: 50, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true),
                    Phone = table.Column<string>(maxLength: 25, nullable: true),
                    Gender = table.Column<int>(nullable: false),
                    Licence = table.Column<int>(nullable: false),
                    AccountState = table.Column<int>(nullable: false)
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
                        name: "FK_Users_FinanceAccounts_BillingAccountId",
                        column: x => x.BillingAccountId,
                        principalTable: "FinanceAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Users_MemberFees_MemberFeeId",
                        column: x => x.MemberFeeId,
                        principalTable: "MemberFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    StreetAndNumber = table.Column<string>(maxLength: 50, nullable: true),
                    City = table.Column<string>(maxLength: 25, nullable: true),
                    PostalCode = table.Column<string>(maxLength: 6, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    Class = table.Column<string>(maxLength: 10, nullable: true),
                    HasClubAccommodation = table.Column<bool>(nullable: false),
                    HasClubTransport = table.Column<bool>(nullable: false),
                    NoteForClub = table.Column<string>(maxLength: 255, nullable: true),
                    NoteForOrganisator = table.Column<string>(maxLength: 255, nullable: true),
                    SiCardNumber = table.Column<int>(nullable: true),
                    Status = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    Text = table.Column<string>(maxLength: 255, nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExecutorId = table.Column<int>(nullable: true),
                    SourceAccountId = table.Column<int>(nullable: true),
                    RecipientAccountId = table.Column<int>(nullable: true),
                    EventId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    CreditAmount = table.Column<int>(nullable: false),
                    Message = table.Column<string>(maxLength: 255, nullable: true),
                    PaymentState = table.Column<int>(nullable: false),
                    StornoNote = table.Column<string>(maxLength: 255, nullable: true)
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
                        name: "FK_Payments_Users_ExecutorId",
                        column: x => x.ExecutorId,
                        principalTable: "Users",
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
                });

            migrationBuilder.CreateTable(
                name: "SiCard",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
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
                    UserId = table.Column<int>(nullable: false),
                    EntriesSupervisorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_EntriesSupervisor", x => new { x.UserId, x.EntriesSupervisorId });
                    table.ForeignKey(
                        name: "FK_User_EntriesSupervisor_Users_EntriesSupervisorId",
                        column: x => x.EntriesSupervisorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_User_EntriesSupervisor_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventEntry_EventStage",
                columns: table => new
                {
                    EventEntryId = table.Column<int>(nullable: false),
                    EventStageId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEntry_EventStage", x => new { x.EventEntryId, x.EventStageId });
                    table.ForeignKey(
                        name: "FK_EventEntry_EventStage_EventEntries_EventEntryId",
                        column: x => x.EventEntryId,
                        principalTable: "EventEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EventEntry_EventStage_EventStage_EventStageId",
                        column: x => x.EventStageId,
                        principalTable: "EventStage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "AccommodationOption", "EndDate", "Entries", "EventProperties", "EventState", "EventType", "Leader", "Link", "Name", "Note", "Organizer", "Place", "StartDate", "TransportOption" },
                values: new object[,]
                {
                    { 1, 2, new DateTime(2020, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 2, 2, null, "mcr2020.obopava.cz", "Soustředění Vysočina", null, "OB ZAM", "Sklené", new DateTime(2020, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 16, 2, 0, null, "mcr2020.obopava.cz", "9. JML - klasická trať", null, "OB ZAM", "Jilemnice", new DateTime(2020, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 }
                });

            migrationBuilder.InsertData(
                table: "FinanceAccounts",
                columns: new[] { "Id", "CreditBalance" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 0 }
                });

            migrationBuilder.InsertData(
                table: "MemberFees",
                columns: new[] { "Id", "Amount", "Description", "MemberFeeType", "Name" },
                values: new object[,]
                {
                    { 2, 0, "Oddílem jsou placeny veškeré závody. Závodník platí pouze storna.", 4, "All Inclusive" },
                    { 1, 100, "Nikam nejezdím nebo málo - veškeré závody se strhávají z osobního vkladu.", 1, "Základ" }
                });

            migrationBuilder.InsertData(
                table: "EventClassOption",
                columns: new[] { "Id", "EventId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "A" },
                    { 2, 1, "B" },
                    { 3, 2, "A" },
                    { 4, 2, "B" },
                    { 5, 2, "H20" }
                });

            migrationBuilder.InsertData(
                table: "EventDeadline",
                columns: new[] { "Id", "Deadline", "EventId" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccountId", "AccountState", "BillingAccountId", "DateOfBirth", "Email", "Firstname", "Gender", "Licence", "MemberFeeId", "Nationality", "Phone", "RegistrationNumber", "Surname" },
                values: new object[,]
                {
                    { 2, 1, 0, 1, null, "tst2@eob.cz", "Kateřina", 1, 2, null, "Česká republika", null, "***REMOVED***", "***REMOVED***" },
                    { 1, 2, 3, 1, null, "tst2@eof.cz", "Matěj", 0, 0, null, "Česká republika", null, "***REMOVED***", "***REMOVED***" }
                });

            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "City", "PostalCode", "StreetAndNumber", "UserId" },
                values: new object[,]
                {
                    { 2, "Brno - Horní Heršpice", "***REMOVED***", null, 2 },
                    { 1, "Brno", "***REMOVED***", "***REMOVED***", 1 }
                });

            migrationBuilder.InsertData(
                table: "EventEntries",
                columns: new[] { "Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, "A", 1, true, true, null, null, ***REMOVED***, 0, 2 },
                    { 2, "H20", 2, true, true, null, null, ***REMOVED***, 0, 1 }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "Date", "Text", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2020, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "1111111111111111111111111111111111111111111111111111111111111111111111111111111", "test nadpisu", 1 });

            migrationBuilder.InsertData(
                table: "Payments",
                columns: new[] { "Id", "CreditAmount", "Date", "EventId", "ExecutorId", "Message", "PaymentState", "RecipientAccountId", "SourceAccountId", "StornoNote" },
                values: new object[] { 1, 1000, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null, 0, 2, 1, null });

            migrationBuilder.InsertData(
                table: "SiCard",
                columns: new[] { "Id", "IsDefault", "Number", "UserId" },
                values: new object[,]
                {
                    { 2, true, ***REMOVED***, 2 },
                    { 1, true, ***REMOVED***, 1 }
                });

            migrationBuilder.InsertData(
                table: "User_EntriesSupervisor",
                columns: new[] { "UserId", "EntriesSupervisorId" },
                values: new object[] { 2, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId",
                unique: true);

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
                name: "IX_EventEntry_EventStage_EventStageId",
                table: "EventEntry_EventStage",
                column: "EventStageId");

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
                name: "IX_User_EntriesSupervisor_EntriesSupervisorId",
                table: "User_EntriesSupervisor",
                column: "EntriesSupervisorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AccountId",
                table: "Users",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BillingAccountId",
                table: "Users",
                column: "BillingAccountId");

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
                name: "EventClassOption");

            migrationBuilder.DropTable(
                name: "EventDeadline");

            migrationBuilder.DropTable(
                name: "EventEntry_EventStage");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "SiCard");

            migrationBuilder.DropTable(
                name: "User_EntriesSupervisor");

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
