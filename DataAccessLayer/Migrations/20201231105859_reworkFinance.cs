using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class reworkFinance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_FinanceAccounts_BillingAccountId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_BillingAccountId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "BillingAccountId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "FinanceSupervisorId",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "FinanceSupervisorId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_FinanceSupervisorId",
                table: "Users",
                column: "FinanceSupervisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_FinanceSupervisorId",
                table: "Users",
                column: "FinanceSupervisorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_FinanceSupervisorId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_FinanceSupervisorId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "FinanceSupervisorId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "BillingAccountId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "BillingAccountId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "BillingAccountId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Users_BillingAccountId",
                table: "Users",
                column: "BillingAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_FinanceAccounts_BillingAccountId",
                table: "Users",
                column: "BillingAccountId",
                principalTable: "FinanceAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
