using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ECommerceContext.Migrations
{
    /// <inheritdoc />
    public partial class multitasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductID1",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 1,
                column: "ProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 2,
                column: "ProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 3,
                column: "ProductID1",
                value: null);

            migrationBuilder.UpdateData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 4,
                column: "ProductID1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductID1",
                table: "OrderDetails",
                column: "ProductID1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Products_ProductID1",
                table: "OrderDetails",
                column: "ProductID1",
                principalTable: "Products",
                principalColumn: "ProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Products_ProductID1",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductID1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ProductID1",
                table: "OrderDetails");
        }
    }
}
