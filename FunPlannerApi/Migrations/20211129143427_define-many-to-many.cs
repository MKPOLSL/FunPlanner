using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunPlannerApi.Migrations
{
    public partial class definemanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_Persons_CreatorId",
                table: "CalendarEvents");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_CalendarEvents_CalendarEventId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_CalendarEventId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CalendarEventId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "EventParticipants",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventParticipants", x => new { x.PersonId, x.EventId });
                    table.ForeignKey(
                        name: "FK_EventParticipants_CalendarEvents_EventId",
                        column: x => x.EventId,
                        principalTable: "CalendarEvents",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EventParticipants_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_EventId",
                table: "EventParticipants",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_Persons_CreatorId",
                table: "CalendarEvents",
                column: "CreatorId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CalendarEvents_Persons_CreatorId",
                table: "CalendarEvents");

            migrationBuilder.DropTable(
                name: "EventParticipants");

            migrationBuilder.AddColumn<Guid>(
                name: "CalendarEventId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CalendarEventId",
                table: "Persons",
                column: "CalendarEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_CalendarEvents_Persons_CreatorId",
                table: "CalendarEvents",
                column: "CreatorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_CalendarEvents_CalendarEventId",
                table: "Persons",
                column: "CalendarEventId",
                principalTable: "CalendarEvents",
                principalColumn: "Id");
        }
    }
}
