using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class InitialCreate09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "***REMOVED***");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "9. JML  klasická trať");

            migrationBuilder.UpdateData(
                table: "MemberFees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Nikam nejezdím nebo málo  veškeré závody se strhávají z osobního vkladu.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Address",
                keyColumn: "Id",
                keyValue: 2,
                column: "City",
                value: "Brno - Horní Heršpice");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "9. JML - klasická trať");

            migrationBuilder.UpdateData(
                table: "MemberFees",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: "Nikam nejezdím nebo málo - veškeré závody se strhávají z osobního vkladu.");
        }
    }
}
