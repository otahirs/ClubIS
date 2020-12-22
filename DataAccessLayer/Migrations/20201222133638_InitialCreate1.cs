using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class InitialCreate1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EventEntries",
                columns: new[] { "Id", "Class", "EventId", "HasClubAccommodation", "HasClubTransport", "NoteForClub", "NoteForOrganisator", "SiCardNumber", "UserId" },
                values: new object[] { 2, "H20", 2, true, true, null, null, null, 1 });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClassOptions",
                value: "[\"A\",\"B\",\"H20\"]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EventEntries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClassOptions",
                value: "[\"A\",\"B\"]");
        }
    }
}
