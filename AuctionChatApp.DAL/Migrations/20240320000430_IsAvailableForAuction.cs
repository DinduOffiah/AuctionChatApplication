using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AuctionChatApp.DAL.Migrations
{
    /// <inheritdoc />
    public partial class IsAvailableForAuction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAvailableForAuction",
                table: "AuctionItem",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAvailableForAuction",
                table: "AuctionItem");
        }
    }
}
