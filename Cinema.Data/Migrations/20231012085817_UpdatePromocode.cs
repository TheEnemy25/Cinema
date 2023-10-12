using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cinema.Data.Migrations
{
    public partial class UpdatePromocode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPromoCode_AspNetUsers_UserId",
                table: "ProductPromoCode");

            migrationBuilder.DropForeignKey(
                name: "FK_SessionPromoCode_AspNetUsers_UserId",
                table: "SessionPromoCode");

            migrationBuilder.DropTable(
                name: "PromoCodeUsage");

            migrationBuilder.DropIndex(
                name: "IX_SessionPromoCode_UserId",
                table: "SessionPromoCode");

            migrationBuilder.DropIndex(
                name: "IX_ProductPromoCode_UserId",
                table: "ProductPromoCode");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "SessionPromoCode");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ProductPromoCode");

            migrationBuilder.CreateTable(
                name: "UserProductPromoCode",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductPromoCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProductPromoCode", x => new { x.UserId, x.ProductPromoCodeId });
                    table.ForeignKey(
                        name: "FK_UserProductPromoCode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserProductPromoCode_ProductPromoCode_ProductPromoCodeId",
                        column: x => x.ProductPromoCodeId,
                        principalTable: "ProductPromoCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserSessionPromoCode",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SessionPromoCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessionPromoCode", x => new { x.UserId, x.SessionPromoCodeId });
                    table.ForeignKey(
                        name: "FK_UserSessionPromoCode_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionPromoCode_SessionPromoCode_SessionPromoCodeId",
                        column: x => x.SessionPromoCodeId,
                        principalTable: "SessionPromoCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserProductPromoCode_ProductPromoCodeId",
                table: "UserProductPromoCode",
                column: "ProductPromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionPromoCode_SessionPromoCodeId",
                table: "UserSessionPromoCode",
                column: "SessionPromoCodeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProductPromoCode");

            migrationBuilder.DropTable(
                name: "UserSessionPromoCode");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "SessionPromoCode",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ProductPromoCode",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "PromoCodeUsage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductPromoCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SessionPromoCodeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsageDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromoCodeUsage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PromoCodeUsage_ProductPromoCode_ProductPromoCodeId",
                        column: x => x.ProductPromoCodeId,
                        principalTable: "ProductPromoCode",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PromoCodeUsage_SessionPromoCode_SessionPromoCodeId",
                        column: x => x.SessionPromoCodeId,
                        principalTable: "SessionPromoCode",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessionPromoCode_UserId",
                table: "SessionPromoCode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPromoCode_UserId",
                table: "ProductPromoCode",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeUsage_ProductPromoCodeId",
                table: "PromoCodeUsage",
                column: "ProductPromoCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PromoCodeUsage_SessionPromoCodeId",
                table: "PromoCodeUsage",
                column: "SessionPromoCodeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPromoCode_AspNetUsers_UserId",
                table: "ProductPromoCode",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SessionPromoCode_AspNetUsers_UserId",
                table: "SessionPromoCode",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
