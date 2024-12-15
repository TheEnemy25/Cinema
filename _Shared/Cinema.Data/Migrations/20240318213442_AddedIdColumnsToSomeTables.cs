using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Data.Migrations
{
    public partial class AddedIdColumnsToSomeTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSessionPromoCode",
                table: "UserSessionPromoCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProductPromoCode",
                table: "UserProductPromoCode");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSeats",
                table: "SessionSeats");

            migrationBuilder.DropColumn(
                name: "SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SessionSeatSessionId",
                table: "Ticket");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserSessionPromoCode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "UserProductPromoCode",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "SessionSeats",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSessionPromoCode",
                table: "UserSessionPromoCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProductPromoCode",
                table: "UserProductPromoCode",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSeats",
                table: "SessionSeats",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionPromoCode_UserId",
                table: "UserSessionPromoCode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProductPromoCode_UserId",
                table: "UserProductPromoCode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SessionSeatId",
                table: "Ticket",
                column: "SessionSeatId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionSeats_SessionId",
                table: "SessionSeats",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatId",
                table: "Ticket",
                column: "SessionSeatId",
                principalTable: "SessionSeats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserSessionPromoCode",
                table: "UserSessionPromoCode");

            migrationBuilder.DropIndex(
                name: "IX_UserSessionPromoCode_UserId",
                table: "UserSessionPromoCode");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProductPromoCode",
                table: "UserProductPromoCode");

            migrationBuilder.DropIndex(
                name: "IX_UserProductPromoCode_UserId",
                table: "UserProductPromoCode");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SessionSeatId",
                table: "Ticket");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SessionSeats",
                table: "SessionSeats");

            migrationBuilder.DropIndex(
                name: "IX_SessionSeats_SessionId",
                table: "SessionSeats");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserSessionPromoCode");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserProductPromoCode");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SessionSeats");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionSeatSeatId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "SessionSeatSessionId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserSessionPromoCode",
                table: "UserSessionPromoCode",
                columns: new[] { "UserId", "SessionPromoCodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProductPromoCode",
                table: "UserProductPromoCode",
                columns: new[] { "UserId", "ProductPromoCodeId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_SessionSeats",
                table: "SessionSeats",
                columns: new[] { "SessionId", "SeatId" });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket",
                columns: new[] { "SessionSeatSessionId", "SessionSeatSeatId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket",
                columns: new[] { "SessionSeatSessionId", "SessionSeatSeatId" },
                principalTable: "SessionSeats",
                principalColumns: new[] { "SessionId", "SeatId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}
