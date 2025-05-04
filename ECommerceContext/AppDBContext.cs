using ECommerceModels.Enums;
using EcommercModels;
using Microsoft.EntityFrameworkCore;

namespace ECommerceContext
{
    public class AppDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=EcommerceProject;Integrated Security=true;Trusted_Connection=True;TrustServerCertificate=True");
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


            #endregion


        }
    }
}
