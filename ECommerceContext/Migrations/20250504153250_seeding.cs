using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ECommerceContext.Migrations
{
    /// <inheritdoc />
    public partial class seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastLoginDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Username",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Role",
                table: "Products",
                newName: "UnitsInStock");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Products",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Products",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "ProductID");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Products",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryID", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic devices and gadgets", "Electronics" },
                    { 2, "Apparel and accessories", "Clothing" },
                    { 3, "Literature and educational materials", "Books" },
                    { 4, "Appliances for home use", "Home Appliances" },
                    { 5, "Sports equipment and apparel", "Sports" },
                    { 6, "Children's toys and games", "Toys" },
                    { 7, "Beauty and personal care products", "Beauty" },
                    { 8, "Automotive parts and accessories", "Automotive" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "DateCreated", "Email", "FirstName", "LastLoginDate", "LastName", "Password", "Role", "Username" },
                values: new object[] { 1, new DateTime(2025, 5, 4, 18, 32, 50, 84, DateTimeKind.Local).AddTicks(2182), "3al@gmail.com", "Alaa", new DateTime(2025, 5, 4, 18, 32, 50, 86, DateTimeKind.Local).AddTicks(8641), "Mobarak", "asdasdasa", 2, "lolomomo" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "DateProcessed", "OrderDate", "Status", "TotalAmount", "UserID" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 5, 4, 18, 32, 50, 87, DateTimeKind.Local).AddTicks(305), 0, 699.99m, 1 },
                    { 2, null, new DateTime(2025, 5, 4, 18, 32, 50, 87, DateTimeKind.Local).AddTicks(894), 3, 19.99m, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "CategoryID", "Description", "ImagePath", "Name", "Price", "UnitsInStock" },
                values: new object[,]
                {
                    { 1, 1, "Latest model smartphone", null, "Smartphone", 699.99m, 50 },
                    { 2, 1, "High-performance laptop", null, "Laptop", 1299.99m, 30 },
                    { 3, 2, "Cotton t-shirt", null, "T-shirt", 19.99m, 100 },
                    { 4, 2, "Denim jeans", null, "Jeans", 49.99m, 80 },
                    { 5, 3, "Bestselling novel", null, "Novel", 14.99m, 200 },
                    { 6, 4, "Electric cooker", null, "Cooker", 89.99m, 40 },
                    { 7, 5, "Official size soccer ball", null, "Soccer Ball", 29.99m, 60 },
                    { 8, 6, "Collectible action figure", null, "Action Figure", 24.99m, 150 },
                    { 9, 7, "Long-lasting lipstick", null, "Lipstick", 15.99m, 120 },
                    { 10, 8, "12V car battery", null, "Car Battery", 89.99m, 20 }
                });

            migrationBuilder.InsertData(
                table: "CartItems",
                columns: new[] { "CartItemID", "DateAdded", "ProductID", "Quantity", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 5, 4, 15, 32, 50, 87, DateTimeKind.Utc).AddTicks(2508), 1, 1, 1 },
                    { 2, new DateTime(2025, 5, 4, 15, 32, 50, 87, DateTimeKind.Utc).AddTicks(3271), 3, 2, 1 },
                    { 3, new DateTime(2025, 5, 4, 15, 32, 50, 87, DateTimeKind.Utc).AddTicks(3272), 4, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailID", "OrderID", "ProductID", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 3, 2 },
                    { 3, 1, 2, 1 },
                    { 4, 2, 4, 1 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CartItems",
                keyColumn: "CartItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "OrderDetailID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UnitsInStock",
                table: "Products",
                newName: "Role");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Products",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Products",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "ProductID",
                table: "Products",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastLoginDate",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }
    }
}
