using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Supermarket.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Receipts_ReceiptId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ReceiptId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ReceiptId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ReceiptId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ReceiptId",
                table: "Products",
                column: "ReceiptId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Receipts_ReceiptId",
                table: "Products",
                column: "ReceiptId",
                principalTable: "Receipts",
                principalColumn: "ReceiptId");
        }
    }
}
