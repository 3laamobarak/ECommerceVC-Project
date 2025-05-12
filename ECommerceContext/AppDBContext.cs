using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceContext
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //"Server=your_server;Database=your_db;Trusted_Connection=True;MultipleActiveResultSets=true;"
            optionsBuilder.UseSqlServer("Server=.;Database=EcommerceProject;Integrated Security=true;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=True");
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Seeding Data

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Electronics", Description = "Electronic devices and gadgets" },
                new Category { CategoryID = 2, Name = "Clothing", Description = "Apparel and accessories" },
                new Category { CategoryID = 3, Name = "Books", Description = "Literature and educational materials" },
                new Category { CategoryID = 4, Name = "Home Appliances", Description = "Appliances for home use" },
                new Category { CategoryID = 5, Name = "Sports", Description = "Sports equipment and apparel" },
                new Category { CategoryID = 6, Name = "Toys", Description = "Children's toys and games" },
                new Category { CategoryID = 7, Name = "Beauty", Description = "Beauty and personal care products" },
                new Category { CategoryID = 8, Name = "Automotive", Description = "Automotive parts and accessories" }
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductID = 1, Name = "Smartphone", Description = "Latest model smartphone", Price = 699.99m, UnitsInStock = 50, CategoryID = 1 },
                new Product { ProductID = 2, Name = "Laptop", Description = "High-performance laptop", Price = 1299.99m, UnitsInStock = 30, CategoryID = 1 },
                new Product { ProductID = 3, Name = "T-shirt", Description = "Cotton t-shirt", Price = 19.99m, UnitsInStock = 100, CategoryID = 2 },
                new Product { ProductID = 4, Name = "Jeans", Description = "Denim jeans", Price = 49.99m, UnitsInStock = 80, CategoryID = 2 },
                new Product { ProductID = 5, Name = "Novel", Description = "Bestselling novel", Price = 14.99m, UnitsInStock = 200, CategoryID = 3 },
                new Product { ProductID = 6, Name = "Cooker", Description = "Electric cooker", Price = 89.99m, UnitsInStock = 40, CategoryID = 4 },
                new Product { ProductID = 7, Name = "Soccer Ball", Description = "Official size soccer ball", Price = 29.99m, UnitsInStock = 60, CategoryID = 5 },
                new Product { ProductID = 8, Name = "Action Figure", Description = "Collectible action figure", Price = 24.99m, UnitsInStock = 150, CategoryID = 6 },
                new Product { ProductID = 9, Name = "Lipstick", Description = "Long-lasting lipstick", Price = 15.99m, UnitsInStock = 120, CategoryID = 7 },
                new Product { ProductID = 10, Name = "Car Battery", Description = "12V car battery", Price = 89.99m, UnitsInStock = 20, CategoryID = 8 }
            );
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "lolomomo", DateCreated = new DateTime(2023, 1, 1), Email = "3al@gmail.com", FirstName = "Alaa", LastName = "Mobarak", LastLoginDate = new DateTime(2023, 1, 5), Password = "asdasdasa", Role = UserRole.SuperAdmin }
            );
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderID = 1, UserID = 1, OrderDate = new DateTime(2023, 1, 1), TotalAmount = 699.99m, Status = OrderStatus.Pending },
                new Order { OrderID = 2, UserID = 1, OrderDate = new DateTime(2023, 1, 1), TotalAmount = 19.99m, Status = OrderStatus.Shipped }
            );
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailID = 1, OrderID = 1, ProductID = 1, Quantity = 1 },
                new OrderDetail { OrderDetailID = 2, OrderID = 2, ProductID = 3, Quantity = 2 },
                new OrderDetail { OrderDetailID = 3, OrderID = 1, ProductID = 2, Quantity = 1 },
                new OrderDetail { OrderDetailID = 4, OrderID = 2, ProductID = 4, Quantity = 1 }
            );
            modelBuilder.Entity<CartItem>().HasData(
                new CartItem { CartItemID = 1, UserID = 1, ProductID = 1, Quantity = 1, DateAdded = new DateTime(2002, 2, 2) },
                new CartItem { CartItemID = 2, UserID = 1, ProductID = 3, Quantity = 2, DateAdded = new DateTime(2002, 2, 2) },
                new CartItem { CartItemID = 3, UserID = 1, ProductID = 4, Quantity = 1, DateAdded = new DateTime(2002, 2, 2) }
            );

            #endregion

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Order)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey(od => od.OrderID);

            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Product)
                .WithMany()
                .HasForeignKey(od => od.ProductID);
        }
    }
}
