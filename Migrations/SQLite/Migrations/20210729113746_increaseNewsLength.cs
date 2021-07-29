using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.Migrations.SQLite.Migrations
{
    public partial class increaseNewsLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ef9ba9b8-085d-4814-921c-71f8acb9a705");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "f30a77c8-649a-4cdf-b71c-d5342aea92e9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "0050bd8f-a56f-4a39-87e8-6b6d1e632075");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "91c5d8a9-995b-4f57-b0bc-f1055e60cbfe");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "c54f0821-a06b-4d60-8e34-a5d09d6390f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "5823520e-864b-421e-b824-e05fc4e54efa");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1dc19f6a-12b0-4766-84c9-fc2753cbe51b", "AQAAAAEAACcQAAAAEDsqBZN/wb7I/t2qJHSEVFRdXFMdHVbMr129larljssHEegFzyOpWeFFZSsj32MGkw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8537196f-bf9c-4fac-b012-711ba8695e28", "AQAAAAEAACcQAAAAEAlblqhdrH2VP2jYzAisbgW+U+gqGs+RiPW/P7V/9b/G6JcaSHnaG5dfER+K3TJpjQ==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "53b2e2cd-bc99-46ad-a8b3-63849c4a84a0");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "bd3237ea-db65-451e-b9ed-660cc0bc133a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "84f104b2-30f7-48b2-98d9-c0a2f82fea95");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "63ee3670-a95c-4976-b4f1-22e95494cb7f");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "1dd7bb1d-13d6-4e86-9df2-bd1770c47f7a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "0d514b4e-32b6-4a49-8dce-fe43625ae103");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "3358c6d8-0dde-42d5-94c6-bff4e3968cda", "AQAAAAEAACcQAAAAEPj9XP6T3a/P8NovcANlCHFJry8T+gGFLgUXoV90I6JZcmU3B1GfjxC/C5tR74GtDA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d39b63ee-8ac0-4fec-9c9e-1fb099b85db8", "AQAAAAEAACcQAAAAEEz9ls4ZKtmdYc6PvQRY3n/rREW18MDbzI8CjZljEupC0qR+ba+7G99lMG4RlqekEQ==" });
        }
    }
}
