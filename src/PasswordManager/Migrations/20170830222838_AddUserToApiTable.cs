using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PasswordManager.Migrations
{
    public partial class AddUserToApiTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Apis",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Apis_UserId",
                table: "Apis",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Apis_AspNetUsers_UserId",
                table: "Apis",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apis_AspNetUsers_UserId",
                table: "Apis");

            migrationBuilder.DropIndex(
                name: "IX_Apis_UserId",
                table: "Apis");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Apis");
        }
    }
}
