using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ClubIS.DataAccessLayer.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventEnteredStage");

            migrationBuilder.AddColumn<int>(
                name: "EventEntryId",
                table: "EventStage",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventStage_EventEntryId",
                table: "EventStage",
                column: "EventEntryId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventStage_EventEntries_EventEntryId",
                table: "EventStage",
                column: "EventEntryId",
                principalTable: "EventEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventStage_EventEntries_EventEntryId",
                table: "EventStage");

            migrationBuilder.DropIndex(
                name: "IX_EventStage_EventEntryId",
                table: "EventStage");

            migrationBuilder.DropColumn(
                name: "EventEntryId",
                table: "EventStage");

            migrationBuilder.CreateTable(
                name: "EventEnteredStage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", maxLength: 50, nullable: false),
                    EventEntryId = table.Column<int>(type: "int", nullable: true),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventEnteredStage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventEnteredStage_EventEntries_EventEntryId",
                        column: x => x.EventEntryId,
                        principalTable: "EventEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventEnteredStage_EventEntryId",
                table: "EventEnteredStage",
                column: "EventEntryId");
        }
    }
}
