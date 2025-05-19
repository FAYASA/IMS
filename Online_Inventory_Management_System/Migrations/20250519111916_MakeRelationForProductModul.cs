using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Inventory_Management_System.Migrations
{
    /// <inheritdoc />
    public partial class MakeRelationForProductModul : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_products_BranchId",
                table: "products",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CurrencyId",
                table: "products",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_Branches_BranchId",
                table: "products",
                column: "BranchId",
                principalTable: "Branches",
                principalColumn: "BranchId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Currencies_CurrencyId",
                table: "products",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_Branches_BranchId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Currencies_CurrencyId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_BranchId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CurrencyId",
                table: "products");
        }
    }
}
