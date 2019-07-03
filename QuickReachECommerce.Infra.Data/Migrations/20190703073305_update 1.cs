using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickReach.ECommerce.Infra.Data.Migrations
{
    public partial class update1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CartID1",
                table: "CartItem",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CartItem_CartID1",
                table: "CartItem",
                column: "CartID1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItem_Cart_CartID1",
                table: "CartItem",
                column: "CartID1",
                principalTable: "Cart",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItem_Cart_CartID1",
                table: "CartItem");

            migrationBuilder.DropIndex(
                name: "IX_CartItem_CartID1",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CartID1",
                table: "CartItem");
        }
    }
}
