using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class CreateNoteDetailTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetail_Notes_NoteId",
                table: "NoteDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteDetail",
                table: "NoteDetail");

            migrationBuilder.RenameTable(
                name: "NoteDetail",
                newName: "NoteDetails");

            migrationBuilder.RenameIndex(
                name: "IX_NoteDetail_NoteId",
                table: "NoteDetails",
                newName: "IX_NoteDetails_NoteId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "NoteDetails",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "NoteDetails",
                type: "datetime2(0)",
                precision: 0,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteDetails",
                table: "NoteDetails",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetails_Notes_NoteId",
                table: "NoteDetails",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NoteDetails_Notes_NoteId",
                table: "NoteDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NoteDetails",
                table: "NoteDetails");

            migrationBuilder.RenameTable(
                name: "NoteDetails",
                newName: "NoteDetail");

            migrationBuilder.RenameIndex(
                name: "IX_NoteDetails_NoteId",
                table: "NoteDetail",
                newName: "IX_NoteDetail_NoteId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastModified",
                table: "NoteDetail",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "NoteDetail",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2(0)",
                oldPrecision: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_NoteDetail",
                table: "NoteDetail",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_NoteDetail_Notes_NoteId",
                table: "NoteDetail",
                column: "NoteId",
                principalTable: "Notes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
