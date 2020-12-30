using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class paymentRework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_RecipientUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_SourceUserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_RecipientUserId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_SourceUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "RecipientUserId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "SourceUserId",
                table: "Payments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RecipientUserId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SourceUserId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_RecipientUserId",
                table: "Payments",
                column: "RecipientUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_SourceUserId",
                table: "Payments",
                column: "SourceUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_RecipientUserId",
                table: "Payments",
                column: "RecipientUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_SourceUserId",
                table: "Payments",
                column: "SourceUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
