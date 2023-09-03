using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Data.Migrations
{
    public partial class FixRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CinemaTheater_Rental_RentalId",
                table: "CinemaTheater");

            migrationBuilder.DropIndex(
                name: "IX_CinemaTheater_RentalId",
                table: "CinemaTheater");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "RentalId",
                table: "CinemaTheater");

            migrationBuilder.AddColumn<Guid>(
                name: "SessionSeatId",
                table: "Ticket",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.AlterColumn<Guid>(
                name: "SeatId",
                table: "ShoppingCartItem",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "SessionSeats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket",
                columns: new[] { "SessionSeatSessionId", "SessionSeatSeatId" });

            migrationBuilder.CreateIndex(
                name: "IX_Rental_CinemaTheaterId",
                table: "Rental",
                column: "CinemaTheaterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rental_CinemaTheater_CinemaTheaterId",
                table: "Rental",
                column: "CinemaTheaterId",
                principalTable: "CinemaTheater",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket",
                columns: new[] { "SessionSeatSessionId", "SessionSeatSeatId" },
                principalTable: "SessionSeats",
                principalColumns: new[] { "SessionId", "SeatId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rental_CinemaTheater_CinemaTheaterId",
                table: "Rental");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_SessionSeats_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_SessionSeatSessionId_SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Rental_CinemaTheaterId",
                table: "Rental");

            migrationBuilder.DropColumn(
                name: "SessionSeatId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SessionSeatSeatId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SessionSeatSessionId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "SessionSeats");

            migrationBuilder.AlterColumn<Guid>(
                name: "SeatId",
                table: "ShoppingCartItem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Seat",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "RentalId",
                table: "CinemaTheater",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_CinemaTheater_RentalId",
                table: "CinemaTheater",
                column: "RentalId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CinemaTheater_Rental_RentalId",
                table: "CinemaTheater",
                column: "RentalId",
                principalTable: "Rental",
                principalColumn: "Id");
        }
    }
}
