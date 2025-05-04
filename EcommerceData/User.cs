using ECommerceModels.Enums;
using System.ComponentModel.DataAnnotations;

namespace EcommercModels
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required, MaxLength(100)][EmailAddress]
        public string Email { get; set; }
        [Required, MaxLength(50)]
        public string FirstName { get; set; }
        [Required, MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public UserRole Role { get; set; }
        public IsActive IsActive { get; set; } = IsActive.Active;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime? LastLoginDate { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<CartItem> CartItems { get; set; }
    }   
}
