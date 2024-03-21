using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class Second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_AuctionItem_ItemId",
                table: "Bids");

            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_ItemId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_UserId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bids");

            migrationBuilder.AddColumn<string>(
                name: "ItemUniqueNumber",
                table: "Bids",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StopTime",
                table: "AuctionItem",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemUniqueNumber",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "StopTime",
                table: "AuctionItem");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndTime",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "Bids",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bids",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_ItemId",
                table: "Bids",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Bids_UserId",
                table: "Bids",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_AuctionItem_ItemId",
                table: "Bids",
                column: "ItemId",
                principalTable: "AuctionItem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Users_UserId",
                table: "Bids",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
