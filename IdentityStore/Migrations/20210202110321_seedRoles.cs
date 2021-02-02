using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.IdentityStore.Migrations
{
    public partial class seedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "be3cbb89-2d48-4925-af98-e42beffdf55f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "9197ba94-c970-42cc-805f-34811845e835", "entries", "ENTRIES" },
                    { 3, "6ed50d5b-4550-45e0-94ad-4a681a48eb4c", "events", "EVENTS" },
                    { 4, "b425c946-4918-4dc3-b8f0-fa6753a35c49", "finance", "FINANCE" },
                    { 5, "6d7c6785-9918-4051-8234-5e6e71054287", "news", "NEWS" },
                    { 6, "eae00a41-d63c-4350-becd-6f1ffc1a084f", "users", "USERS" }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e3374dae-1bc2-4993-9d43-210e0ebeb396", "AQAAAAEAACcQAAAAEEVVSYlkQ0TQtjT9AG1zwrw0cKSvjOVcd4EOiwhsSLsq4Kbt0r90bYG2vBWpiwLNBw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6ee653d5-7e04-4821-adbd-e67ad77c87e3", "AQAAAAEAACcQAAAAEB/+p+FYGxgNNCoHkkc9wwhLUlOFeRP5NYRl/qj5Wxac4X9ikG7uadBuDYZ5dt/z0g==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "6d617b3c-6b33-48da-abee-46479b7f27cd");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2025e489-79e8-474d-969c-47d4afd7a184", "AQAAAAEAACcQAAAAEOrAV6bfIbVsj9z8WnvF4f99vZ/Mv9M3Bsg71c6ewiXb7rSDdzmfDFs5x7RnXFQucA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b6e743fe-ee67-4cbd-85c1-847c5e444913", "AQAAAAEAACcQAAAAECPTTh5VR+xTSsVR2HEt5/OcCztnPjMySKweua2a9Ekfo46LHweXqOfj2UHUltrAQg==" });
        }
    }
}
