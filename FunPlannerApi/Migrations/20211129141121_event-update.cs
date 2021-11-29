using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunPlannerApi.Migrations
{
    public partial class eventupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CalendarEventId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "CalendarEvents",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "EventRegistration",
                table: "CalendarEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsLimited",
                table: "CalendarEvents",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Limit",
                table: "CalendarEvents",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Place",
                table: "CalendarEvents",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_CalendarEventId",
                table: "Persons",
                column: "CalendarEventId");

            migrationBuilder.CreateIndex(
                name: "IX_CalendarEvents_CreatorId",
                table: "CalendarEvents",
                column: "CreatorId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_CalendarEvents_CreatorId",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "CalendarEventId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "EventRegistration",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "IsLimited",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "Limit",
                table: "CalendarEvents");

            migrationBuilder.DropColumn(
                name: "Place",
                table: "CalendarEvents");
        }
    }
}
