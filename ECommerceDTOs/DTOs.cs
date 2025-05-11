using ECommerceModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace ECommerceDTOs
{
    public class CartItemDto
    {
        public int CartItemID { get; set; }
        public int UserID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public DateTime DateAdded { get; set; }
        
        // Navigation properties
        public ProductDto Product { get; set; }
        public UserDto User { get; set; }
    }
    public class CreateOrderDetailDto
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }

    public class UpdateOrderDetailDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1")]
        public int Quantity { get; set; }
    }
    public class CreateOrderDto
    {
        [Required]
        public int UserID { get; set; }
    }

    public class OrderUpdateDto
    {
        public OrderStatus? Status { get; set; }
        public decimal? TotalAmount { get; set; }
    }
    public class OrderDetailDto
    {
        public int OrderDetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        
        // Navigation properties
        public ProductDto Product { get; set; }
    }
    public class OrderDto
    {
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? DateProcessed { get; set; }
        
        // Navigation properties
        public UserDto User { get; set; }
        public List<OrderDetailDto> OrderDetails { get; set; }
    }
    public class ProductDto
    {
        public int ProductID { get; set; }
        [Required][MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }
        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Units in stock cannot be negative")]
        public int UnitsInStock { get; set; }
        [Required]
        public int CategoryID { get; set; }
        [MaxLength(255)]
        public string ImagePath { get; set; }
    
        // Add this for category name
        public string CategoryName { get; set; } // New property
        // Navigation property
        public CategoryDto Category { get; set; }
    }
    public class UserDto
    {
        public int UserID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public UserRole Role { get; set; }
        public IsActive IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? LastLoginDate { get; set; }
        
        // Navigation properties (for UI display purposes)
        public List<OrderDto> Orders { get; set; }
    }
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        // Navigation properties
        public List<ProductDto> Products { get; set; }
    }
}
