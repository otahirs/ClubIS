using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.Migrations.PostgreSQL.Migrations
{
    public partial class increaseNewsLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                type: "character varying(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "189058d7-f064-4707-90a8-5e90672674de");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "009d6684-4f90-4240-926c-022fd4223fd7");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "bc4a6fe6-8a2f-4ef7-b7a3-9943386b85b6");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "e6cc433d-4714-4fea-ba4a-9d38d1a6049e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "bc17a670-9582-46e5-a2da-2ea285e3177c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "b5817ac2-6a4c-4e86-9671-0c1141651da9");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "051e88ba-d861-4bb5-a61b-070f794f76f8", "AQAAAAEAACcQAAAAEBOM7dcCifDx4vU4b2tFng75DTxmQqQm8fKbjkhOvsNGP7p+e4zmZX3MaN//EWcyBg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1246bc2b-7aa4-442d-a436-4be686372955", "AQAAAAEAACcQAAAAEHlta5hHs7qtjLUOdahtClbt9uB3zxe/Dz70NkaWkC6WmCn3euldE0no1us/sSAnFg==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "News",
                type: "character varying(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "8c956876-993b-4fcd-841d-6b299518fa58");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a30f789e-ff5c-4a2d-a1b9-569673f2d876");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3,
                column: "ConcurrencyStamp",
                value: "41a101a4-bf3d-4c7d-be3b-4d8598867107");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcurrencyStamp",
                value: "6129044e-1bdf-4f1c-8624-cedbbf6fc8f8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcurrencyStamp",
                value: "e82a2b1b-eee8-4984-b19c-8ad8a39e643e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 6,
                column: "ConcurrencyStamp",
                value: "9b6f2ab0-c252-4788-8257-c732797e5d34");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "44bf4021-73df-4626-9947-911152427e39", "AQAAAAEAACcQAAAAEEMGQ8gSrmCG5hmb/xcRD1VRD1+6LukW0G9iGAcX26sjjbxXWDvxNE/JHOnkz8YYTQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0b680948-878f-4101-80ab-4bc935ddb4b6", "AQAAAAEAACcQAAAAEOaFGmplizMVcV3vujNjvi350t+g8zhGA3EhiFZ0DY1eOkUnzreSr2ZbNDCs4xa7Hw==" });
        }
    }
}
