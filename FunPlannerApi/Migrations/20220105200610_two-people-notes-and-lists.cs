using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FunPlannerApi.Migrations
{
    public partial class twopeoplenotesandlists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Persons_PersonId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "PersonId",
                table: "Notes",
                newName: "ToPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_PersonId",
                table: "Notes",
                newName: "IX_Notes_ToPersonId");

            migrationBuilder.AddColumn<Guid>(
                name: "FromPersonId",
                table: "Notes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("26878971-2C7A-4627-9D44-5CADDD58775F"));

            migrationBuilder.CreateIndex(
                name: "IX_Notes_FromPersonId",
                table: "Notes",
                column: "FromPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Persons_FromPersonId",
                table: "Notes",
                column: "FromPersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Persons_ToPersonId",
                table: "Notes",
                column: "ToPersonId",
                principalTable: "Persons",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Persons_FromPersonId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Persons_ToPersonId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_FromPersonId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "FromPersonId",
                table: "Notes");

            migrationBuilder.RenameColumn(
                name: "ToPersonId",
                table: "Notes",
                newName: "PersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Notes_ToPersonId",
                table: "Notes",
                newName: "IX_Notes_PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Persons_PersonId",
                table: "Notes",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
