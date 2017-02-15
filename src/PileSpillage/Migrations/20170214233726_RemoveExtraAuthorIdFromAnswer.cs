using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PileSpillage.Migrations
{
    public partial class RemoveExtraAuthorIdFromAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_AuthorId1",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AuthorId1",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "AuthorId1",
                table: "Answers");

            migrationBuilder.AlterColumn<string>(
                name: "AuthorId",
                table: "Answers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_AuthorId",
                table: "Answers",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Answers_AspNetUsers_AuthorId",
                table: "Answers");

            migrationBuilder.DropIndex(
                name: "IX_Answers_AuthorId",
                table: "Answers");

            migrationBuilder.AddColumn<string>(
                name: "AuthorId1",
                table: "Answers",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AuthorId",
                table: "Answers",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AuthorId1",
                table: "Answers",
                column: "AuthorId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Answers_AspNetUsers_AuthorId1",
                table: "Answers",
                column: "AuthorId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
